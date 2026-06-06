using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Data.Services;

public class ValidationIssueService(
    IValidationIssueRepository validationIssueRepository,
    IValidationRuleRepository validationRuleRepository,
    ITransactionRepository transactionRepository) : IValidationIssueService
{
    public async Task<ValidationIssue> ConfirmAsync(Guid id, ConfirmValidationIssueDto dto)
    {
        var issue = await validationIssueRepository.EnsureExistsAsync(id);

        if (issue.Status is ValidationIssueStatus.Resolved or ValidationIssueStatus.Rejected)
            throw new ArgumentException($"Issue {id} is already {issue.Status}");

        if (dto.TransactionIdsToDelete.Count == 0)
            throw new ArgumentException("At least one transaction id to delete is required");

        var issueTransactionIds = issue.Transactions
            .Select(t => t.TransactionId)
            .ToHashSet();

        var unknownIds = dto.TransactionIdsToDelete
            .Where(transactionId => !issueTransactionIds.Contains(transactionId))
            .ToList();

        if (unknownIds.Count > 0)
            throw new ArgumentException($"Transactions do not belong to issue: {string.Join(", ", unknownIds)}");

        if (dto.TransactionIdsToDelete.Count >= issueTransactionIds.Count)
            throw new ArgumentException("At least one transaction must remain in the issue");

        foreach (var transactionId in dto.TransactionIdsToDelete)
        {
            var transaction = await transactionRepository.EnsureExistsAsync(transactionId);
            transaction.IsDeleted = true;
            await transactionRepository.UpdateAsync(transaction);
        }

        issue.Status = ValidationIssueStatus.Resolved;
        if (dto.Comment != null)
            issue.Comment = dto.Comment;

        await validationIssueRepository.UpdateAsync(issue);
        await validationIssueRepository.SaveChangesAsync();

        return issue;
    }

    public async Task<ValidationIssue> CreateAsync(CreateValidationIssueDto dto)
    {
        if (dto.TransactionIds.Count < 2)
            throw new ArgumentException("Validation issue must include at least two transactions");

        await validationRuleRepository.EnsureExistsAsync(dto.RuleId);

        var uniqueTransactionIds = dto.TransactionIds.Distinct().ToList();
        if (uniqueTransactionIds.Count != dto.TransactionIds.Count)
            throw new ArgumentException("Transaction ids must be unique");

        foreach (var transactionId in uniqueTransactionIds)
            await transactionRepository.EnsureExistsAsync(transactionId);

        var issue = new ValidationIssue
        {
            Id = Guid.NewGuid(),
            RuleId = dto.RuleId,
            Status = ValidationIssueStatus.New,
            Comment = dto.Comment,
            CreatedAtUtc = DateTime.UtcNow,
            Transactions = uniqueTransactionIds
                .Select(transactionId => new ValidationIssueTransaction
                {
                    TransactionId = transactionId
                })
                .ToList()
        };

        await validationIssueRepository.AddAsync(issue);
        await validationIssueRepository.SaveChangesAsync();

        return await validationIssueRepository.EnsureExistsAsync(issue.Id);
    }

    public async Task<ValidationIssue> GetByIdAsync(Guid id)
    {
        return await validationIssueRepository.EnsureExistsAsync(id);
    }

    public async Task<List<ValidationIssue>> GetFilteredAsync(ValidationIssueFilter filter)
    {
        return await validationIssueRepository.GetFilteredAsync(filter);
    }

    public async Task<ValidationIssue> RejectAsync(Guid id, RejectValidationIssueDto dto)
    {
        var issue = await validationIssueRepository.EnsureExistsAsync(id);

        if (issue.Status is ValidationIssueStatus.Resolved or ValidationIssueStatus.Rejected)
            throw new ArgumentException($"Issue {id} is already {issue.Status}");

        issue.Status = ValidationIssueStatus.Rejected;
        if (dto.Comment != null)
            issue.Comment = dto.Comment;

        await validationIssueRepository.UpdateAsync(issue);
        await validationIssueRepository.SaveChangesAsync();

        return issue;
    }

    public async Task<ValidationIssue> UpdateAsync(Guid id, UpdateValidationIssueDto dto)
    {
        var issue = await validationIssueRepository.EnsureExistsAsync(id);

        if (issue.Status is ValidationIssueStatus.Resolved or ValidationIssueStatus.Rejected)
            throw new ArgumentException($"Issue {id} cannot be updated in status {issue.Status}");

        if (dto.Comment != null)
            issue.Comment = dto.Comment;

        await validationIssueRepository.UpdateAsync(issue);
        await validationIssueRepository.SaveChangesAsync();

        return issue;
    }
}
