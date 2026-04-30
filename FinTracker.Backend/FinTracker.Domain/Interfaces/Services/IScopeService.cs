using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface IScopeService
{
    Task<Scope?> GetByNameAsync(string name);
}
