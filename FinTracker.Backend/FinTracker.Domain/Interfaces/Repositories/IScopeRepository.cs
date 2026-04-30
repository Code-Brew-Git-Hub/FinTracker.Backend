using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IScopeRepository
{
    Task AddAsync(Scope scope, CancellationToken cancellationToken = default);
}
