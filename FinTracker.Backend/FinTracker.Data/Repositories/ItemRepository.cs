using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories;

public class ItemRepository : IItemRepository
{
    public Task AddAsync(TransactionItem entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TransactionItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TransactionItem>> GetAllByTransactionIdAsync(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionItem?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TransactionItem entity)
    {
        throw new NotImplementedException();
    }
}
