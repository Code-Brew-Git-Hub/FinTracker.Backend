
using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Services;

public interface ICategoryService
{
    Task CreateAsync(string name);
    Task<Category?> GetByNameAsync(string name);
}
