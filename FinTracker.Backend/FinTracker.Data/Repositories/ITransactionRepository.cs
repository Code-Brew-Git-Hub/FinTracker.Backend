using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
        Task<Transaction> GetById(int id);
        Task<List<Transaction>> GetAll();
    }
}
