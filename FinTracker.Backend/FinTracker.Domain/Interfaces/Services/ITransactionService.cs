using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface ITransactionService
{
    Task CreateAsync(decimal amount, string currency, DateTime date, string? description, 
        string? comment, Category category, Scope? scope,
        CancellationToken cancellationToken = default);

    Task<Transaction?> GetByIdAsync(Guid id);

    Task UpdateAsync(Transaction transaction);
}
