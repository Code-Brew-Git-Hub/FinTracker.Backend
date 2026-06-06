using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class ValidationIssueRepository(AppDbContext context) : IValidationIssueRepository
{
    public async Task AddAsync(ValidationIssue entity)
    {
        await context.ValidationIssues.AddAsync(entity);
    }

    public async Task<ValidationIssue?> GetByIdAsync(Guid id)
    {
        return await context.ValidationIssues
            .Include(i => i.Rule)
            .Include(i => i.Transactions)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<ValidationIssue>> GetFilteredAsync(ValidationIssueFilter filter)
    {
        var query = context.ValidationIssues
            .Include(i => i.Rule)
            .Include(i => i.Transactions)
            .AsQueryable();

        if (filter.RuleId != null)
            query = query.Where(i => i.RuleId == filter.RuleId);

        if (filter.Status != null)
            query = query.Where(i => i.Status == filter.Status);

        return await query
            .OrderByDescending(i => i.CreatedAtUtc)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ValidationIssue entity)
    {
        context.ValidationIssues.Update(entity);
    }
}
