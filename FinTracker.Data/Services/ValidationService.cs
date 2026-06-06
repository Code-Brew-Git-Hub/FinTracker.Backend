using FinTracker.Domain;
using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ValidationService(
    IValidationRuleRepository validationRuleRepository,
    IValidationIssueRepository validationIssueRepository,
    ITransactionRepository transactionRepository) : IValidationService
{
    public async Task<RunValidationResultDto> RunIdenticalTransactionsAsync(Guid? ruleId = null)
    {
        var targetRuleId = ruleId ?? ValidationRuleIds.IdenticalTransactions;
        var rule = await validationRuleRepository.EnsureExistsAsync(targetRuleId);

        if (!rule.IsEnabled)
            throw new ArgumentException($"Validation rule '{rule.Name}' is disabled");

        var transactions = await transactionRepository.GetActiveAsync();
        var duplicateGroups = FindIdenticalGroups(transactions);

        var existingIssues = await validationIssueRepository.GetByRuleIdAsync(targetRuleId);
        var skippedKeys = BuildSkippedTransactionSetKeys(existingIssues);

        var createdIssueIds = new List<Guid>();
        var skippedGroups = 0;

        foreach (var group in duplicateGroups)
        {
            var key = BuildTransactionSetKey(group);

            if (skippedKeys.Contains(key))
            {
                skippedGroups++;
                continue;
            }

            var issue = new ValidationIssue
            {
                Id = Guid.NewGuid(),
                RuleId = targetRuleId,
                Status = ValidationIssueStatus.New,
                CreatedAtUtc = DateTime.UtcNow,
                Transactions = group
                    .Select(transactionId => new ValidationIssueTransaction
                    {
                        TransactionId = transactionId
                    })
                    .ToList()
            };

            await validationIssueRepository.AddAsync(issue);
            createdIssueIds.Add(issue.Id);
            skippedKeys.Add(key);
        }

        if (createdIssueIds.Count > 0)
            await validationIssueRepository.SaveChangesAsync();

        return new RunValidationResultDto
        {
            RuleId = targetRuleId,
            FoundGroups = duplicateGroups.Count,
            CreatedIssues = createdIssueIds.Count,
            SkippedGroups = skippedGroups,
            CreatedIssueIds = createdIssueIds
        };
    }

    private static List<List<Guid>> FindIdenticalGroups(IEnumerable<Transaction> transactions)
    {
        return transactions
            .GroupBy(t => (
                t.DateUtc,
                t.Amount,
                t.Currency,
                NormalizeDescription(t.Description)))
            .Where(g => g.Count() >= 2)
            .Select(g => g.Select(t => t.Id).ToList())
            .ToList();
    }

    private static HashSet<string> BuildSkippedTransactionSetKeys(IEnumerable<ValidationIssue> issues)
    {
        return issues
            .Where(i => i.Status is ValidationIssueStatus.Rejected or ValidationIssueStatus.New)
            .Select(i => BuildTransactionSetKey(i.Transactions.Select(t => t.TransactionId)))
            .ToHashSet();
    }

    private static string BuildTransactionSetKey(IEnumerable<Guid> transactionIds) =>
        string.Join("|", transactionIds.OrderBy(id => id));

    private static string? NormalizeDescription(string? description) =>
        string.IsNullOrWhiteSpace(description) ? null : description.Trim();
}
