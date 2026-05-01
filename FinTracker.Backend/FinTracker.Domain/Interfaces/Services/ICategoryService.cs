
using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Services;

public interface ICategoryService
{
    Task<Category> CreateAsync(string name);
    Task<Category[]> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category?> GetByNameAsync(string name);
    Task<bool> IsUniqueNameAsync(string name);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteByIdAsync(Guid id);
}
