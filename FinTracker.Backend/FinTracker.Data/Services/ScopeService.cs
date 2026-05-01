using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ScopeService(IScopeRepository scopeRepository) : IScopeService
{
    public Task<Scope> CreateAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Scope>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Scope> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>> GetTransactionsAsync(Guid scopeId)
    {
        throw new NotImplementedException();
    }

    public Task<Scope> UpdateAsync(Guid id, string name)
    {
        throw new NotImplementedException();
    }
}
