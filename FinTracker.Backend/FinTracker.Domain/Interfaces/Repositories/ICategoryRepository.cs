using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task CreateAsync(Category category);
    Task<Category[]> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category?> GetByNameAsync(string name);
    Task UpdateAsync(Category category);
    Task<bool> IsUniqueNameAsync(string name);
    void Delete(Category category);
}
