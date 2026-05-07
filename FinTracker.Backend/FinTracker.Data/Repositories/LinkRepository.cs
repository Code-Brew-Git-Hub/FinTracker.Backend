using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories;

public class LinkRepository : ILinkRepository
{
    public Task AddAsync(TransactionLink entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TransactionLink>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TransactionLink?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionLink?> GetByIdWithEntriesAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TransactionLink entity)
    {
        throw new NotImplementedException();
    }
}
