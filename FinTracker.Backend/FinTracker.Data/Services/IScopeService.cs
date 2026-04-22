
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface IScopeService
{
    Task CreateAsync(string name, CancellationToken cancellationToken = default);
    Task<Scope?> GetScopeByName(string name);
}
