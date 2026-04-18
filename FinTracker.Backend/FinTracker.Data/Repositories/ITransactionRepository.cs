using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
        Task<Transaction?> GetByIdAsync(int id);
        Task<List<Transaction>> GetAllAsync();
        Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default);
        Task<List<Transaction>> GetByFiltersAsync(TransactionFilters filters);
    }
}
