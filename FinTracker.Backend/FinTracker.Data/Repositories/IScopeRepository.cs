using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories;

public interface IScopeRepository
{
    Task AddAsync(Scope scope, CancellationToken cancellationToken = default);
    Task<Scope?> GetScopeByName(string name);
}
