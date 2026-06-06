using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class ValidationRuleRepository(AppDbContext context) : IValidationRuleRepository
{
    public async Task AddAsync(ValidationRule entity)
    {
        await context.ValidationRules.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var rule = await GetByIdAsync(id);
        if (rule != null)
            context.ValidationRules.Remove(rule);
    }

    public async Task<List<ValidationRule>> GetAllAsync()
    {
        return await context.ValidationRules
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    public async Task<ValidationRule?> GetByIdAsync(Guid id)
    {
        return await context.ValidationRules.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ValidationRule entity)
    {
        context.ValidationRules.Update(entity);
    }
}
