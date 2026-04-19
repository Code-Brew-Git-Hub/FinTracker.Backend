using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
        Task<Transaction?> GetByIdAsync(int id, bool hideDeleted);
        Task<List<Transaction>> GetAllAsync(bool hideDeleted);
        Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default);
        Task<List<Transaction>> GetByFiltersAsync(TransactionFilters filters, bool hideDeleted);
    }
}
