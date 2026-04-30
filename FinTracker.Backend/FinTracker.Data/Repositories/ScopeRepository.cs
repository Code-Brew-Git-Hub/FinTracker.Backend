using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class ScopeRepository(AppContext context) : IScopeRepository
{
    public async Task<Scope?> GetByIdAsync(Guid id)
    {
        return await context.Scopes
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Scope?> GetByNameAsync(string name)
    {
        return await context.Scopes
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Name == name);
    }
}
