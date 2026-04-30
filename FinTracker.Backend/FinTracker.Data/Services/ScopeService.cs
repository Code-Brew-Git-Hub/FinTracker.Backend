using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ScopeService(IScopeRepository scopeRepository) : IScopeService
{
    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        await scopeRepository.AddAsync(new Scope { Name = name });
    }
}
