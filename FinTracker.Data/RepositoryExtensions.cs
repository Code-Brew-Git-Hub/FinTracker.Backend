using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data;

public static class RepositoryExtensions
{
    public static async Task<T> EnsureExistsAsync<T>(
        this IRepository<T> repository, Guid id)
        where T : class
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new KeyNotFoundException($"{typeof(T).Name} {id} not found");

        return entity;
    }
}

public static class LinkRepositoryExtensions
{
    public static async Task<TransactionLink> EnsureExistsWithEntriesAsync(
        this ILinkRepository repository,
        Guid id)
    {
        var link = await repository.GetByIdWithEntriesAsync(id);
        if (link is null)
            throw new KeyNotFoundException($"Link {id} not found");

        return link;
    }
}

public static class TransactionRepositoryExtensions
{
    public static async Task<Transaction> EnsureExistsAsync(
        this ITransactionRepository repository,
        Guid id,
        bool includeDeleted = false)
    {
        var transaction = await repository.GetByIdAsync(id, includeDeleted);
        if (transaction is null)
            throw new KeyNotFoundException($"Transaction {id} not found");

        return transaction;
    }
}

public static class ValidationRuleRepositoryExtensions
{
    public static async Task<ValidationRule> EnsureExistsAsync(
        this IValidationRuleRepository repository,
        Guid id)
    {
        var rule = await repository.GetByIdAsync(id);
        if (rule is null)
            throw new KeyNotFoundException($"ValidationRule {id} not found");

        return rule;
    }
}

public static class ValidationIssueRepositoryExtensions
{
    public static async Task<ValidationIssue> EnsureExistsAsync(
        this IValidationIssueRepository repository,
        Guid id)
    {
        var issue = await repository.GetByIdAsync(id);
        if (issue is null)
            throw new KeyNotFoundException($"ValidationIssue {id} not found");

        return issue;
    }
}