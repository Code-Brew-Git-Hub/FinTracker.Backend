using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task CreateAsync(string name)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        await categoryRepository.CreateAsync(category);
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await categoryRepository.GetByNameAsync(name);
    }
}
