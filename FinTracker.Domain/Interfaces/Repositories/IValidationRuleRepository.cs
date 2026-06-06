using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IValidationRuleRepository
{
    Task<ValidationRule?> GetByIdAsync(Guid id);
    Task<List<ValidationRule>> GetAllAsync();
    Task AddAsync(ValidationRule entity);
    Task UpdateAsync(ValidationRule entity);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}
