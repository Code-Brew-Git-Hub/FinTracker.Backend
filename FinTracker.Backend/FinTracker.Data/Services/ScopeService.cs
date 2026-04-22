
using FinTracker.Data.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ScopeService(IScopeRepository scopeRepository) : IScopeService
{
    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Scope?> GetScopeByName(string name)
    {
        return await scopeRepository.GetScopeByName(name);
    }
}
