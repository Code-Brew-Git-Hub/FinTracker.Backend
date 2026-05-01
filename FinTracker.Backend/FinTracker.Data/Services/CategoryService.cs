using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Category> CreateAsync(string name)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        await categoryRepository.CreateAsync(category);

        return category;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if(category == null)
            return false;
        categoryRepository.Delete(category);
        return true;
    }

    public async Task<Category[]> GetAllAsync()
    {
        return await categoryRepository.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await categoryRepository.GetByIdAsync(id);
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await categoryRepository.GetByNameAsync(name);
    }

    public async Task<bool> IsUniqueNameAsync(string name)
    {
        return await categoryRepository.IsUniqueNameAsync(name);
    }

    public async Task<bool> UpdateAsync(Category newCategory)
    {
        var isUnique = await categoryRepository.IsUniqueNameAsync(newCategory.Name);
        if (isUnique)
            await categoryRepository.UpdateAsync(newCategory);
        return isUnique;
    }
}
