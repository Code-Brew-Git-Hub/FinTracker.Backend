using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class ScopeRepository(AppDbContext context) : IScopeRepository
{
    public Task AddAsync(Scope entity)
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

    public Task<Scope?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Scope entity)
    {
        throw new NotImplementedException();
    }
}
