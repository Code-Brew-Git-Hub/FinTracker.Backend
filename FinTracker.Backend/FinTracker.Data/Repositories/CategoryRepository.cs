
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class CategoryRepository(AppContext context) : ICategoryRepository
{
    public async Task CreateAsync(Category category)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public void Delete(Category category)
    {
        context.Categories.Remove(category);
    }

    public async Task<Category[]> GetAllAsync()
    {
        return await context.Categories
            .AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        var category = await context.Categories
            //.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return category;
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await context.Categories
            //.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<bool> IsUniqueNameAsync(string name)
    {
        return !await context.Categories.AnyAsync(c => c.Name == name);
    }

    public async Task UpdateAsync(Category category)
    {
        context.Categories.Attach(category);
        context.Entry(category).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
