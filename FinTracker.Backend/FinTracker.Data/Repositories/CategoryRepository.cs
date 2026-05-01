
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task AddAsync(Category entity)
    {
        await context.Categories
            .AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await GetByIdAsync(id);
        if (category != null)
        {
            context.Categories
                .Remove(category);
        }            
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await context.Categories
            .ToListAsync();            
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await context.Categories
            .FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category entity)
    {
        context.Categories.Update(entity);
    }
}
