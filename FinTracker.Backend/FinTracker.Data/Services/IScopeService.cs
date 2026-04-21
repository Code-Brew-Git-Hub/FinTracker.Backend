
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface IScopeService
{
    Task CreateAsync(string name, CancellationToken cancellationToken = default);
    Task AddAsync(Scope scope, CancellationToken cancellationToken = default);
    Task<Scope> GetByIdAsync(int id);
    Task<IEnumerable<Scope>> GetAllAsync();
    Task UpdateAsync(Scope scope, CancellationToken cancellationToken = default);
}
