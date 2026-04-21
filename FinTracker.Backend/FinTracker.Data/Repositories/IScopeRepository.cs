using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories;

public interface IScopeRepository
{
    Task AddAsync(Scope scope, CancellationToken cancellationToken = default);
    Task<Scope> GetByIdAsync(int id);
    Task<IEnumerable<Scope>> GetAllAsync();
    Task UpdateAsync(Scope scope, CancellationToken cancellationToken = default);
}
