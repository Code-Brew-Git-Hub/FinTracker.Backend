using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IScopeRepository
{
    Task<Scope?> GetByIdAsync(Guid id);
    Task<Scope?> GetByNameAsync(string name);
}
