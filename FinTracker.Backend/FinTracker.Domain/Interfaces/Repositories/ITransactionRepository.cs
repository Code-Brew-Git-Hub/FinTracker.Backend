using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);

    Task<Transaction?> GetByIdAsync(Guid id);

    Task UpdateAsync(Transaction transaction);
}
