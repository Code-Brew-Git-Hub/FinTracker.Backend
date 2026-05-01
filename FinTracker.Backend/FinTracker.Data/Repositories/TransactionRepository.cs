using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class TransactionRepository(AppDbContext context) : ITransactionRepository
{
    public async Task AddAsync(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public async Task BulkUpdateAsync(IEnumerable<Guid> ids, BulkUpdateData data)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Transaction>> GetByScopeIdAsync(Guid scopeId)
    {
        return await context.Transactions
            .Where(t => t.ScopeId == scopeId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetFilteredAsync(TransactionFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}
