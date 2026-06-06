using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IValidationIssueRepository
{
    Task<ValidationIssue?> GetByIdAsync(Guid id);
    Task<List<ValidationIssue>> GetFilteredAsync(ValidationIssueFilter filter);
    Task AddAsync(ValidationIssue entity);
    Task UpdateAsync(ValidationIssue entity);
    Task SaveChangesAsync();
}
