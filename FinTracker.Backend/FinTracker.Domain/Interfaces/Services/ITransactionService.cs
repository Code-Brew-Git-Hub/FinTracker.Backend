using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface ITransactionService
{
    Task CreateAsync(DateTime date, decimal amount, string currency, Category category,
        string? description, Scope? scope, string? comment, bool isDeleted,
        CancellationToken cancellationToken = default);
}
