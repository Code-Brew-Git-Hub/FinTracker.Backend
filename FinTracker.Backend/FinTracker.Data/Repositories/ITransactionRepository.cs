using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
    }
}
