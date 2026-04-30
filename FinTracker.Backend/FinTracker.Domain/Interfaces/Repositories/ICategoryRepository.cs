using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task CreateAsync(Category category);
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category?> GetByNameAsync(string name);
}
