using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ScopeService(IScopeRepository scopeRepository) : IScopeService
{
    public async Task<Scope?> GetByNameAsync(string name)
    {
        return await scopeRepository.GetByNameAsync(name);
    }
}
