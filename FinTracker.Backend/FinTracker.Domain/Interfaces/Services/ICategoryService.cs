
using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(Guid id);
    Task<Category> CreateAsync(string name);
    Task<Category> UpdateAsync(Guid id, string name);
    Task DeleteAsync(Guid id);
}
