using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Services;

public interface IValidationRuleService
{
    Task<List<ValidationRule>> GetAllAsync();
    Task<ValidationRule> GetByIdAsync(Guid id);
    Task<ValidationRule> CreateAsync(CreateValidationRuleDto dto);
    Task<ValidationRule> UpdateAsync(Guid id, UpdateValidationRuleDto dto);
    Task DeleteAsync(Guid id);
}
