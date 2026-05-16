using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Category> CreateAsync(string name)
    {
        var newCategory = new Category()
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        await categoryRepository.AddAsync(newCategory);
        await categoryRepository.SaveChangesAsync();

        return newCategory;
    }

    public async Task DeleteAsync(Guid id)
    {
        await categoryRepository.DeleteAsync(id);
        await categoryRepository.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await categoryRepository.EnsureExistsAsync(id);
    }

    public async Task<Category> UpdateAsync(Guid id, string name)
    {
        var entity = await categoryRepository.EnsureExistsAsync(id);

        entity.Name = name;
        await categoryRepository.UpdateAsync(entity);
        await categoryRepository.SaveChangesAsync();

        return entity;
    }
}
