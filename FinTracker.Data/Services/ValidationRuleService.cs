using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ValidationRuleService(IValidationRuleRepository validationRuleRepository) : IValidationRuleService
{
    public async Task<ValidationRule> CreateAsync(CreateValidationRuleDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Rule name is required");

        var rule = new ValidationRule
        {
            Id = Guid.NewGuid(),
            Name = dto.Name.Trim(),
            Description = dto.Description,
            IsEnabled = dto.IsEnabled
        };

        await validationRuleRepository.AddAsync(rule);
        await validationRuleRepository.SaveChangesAsync();

        return rule;
    }

    public async Task DeleteAsync(Guid id)
    {
        await validationRuleRepository.EnsureExistsAsync(id);
        await validationRuleRepository.DeleteAsync(id);
        await validationRuleRepository.SaveChangesAsync();
    }

    public async Task<List<ValidationRule>> GetAllAsync()
    {
        return await validationRuleRepository.GetAllAsync();
    }

    public async Task<ValidationRule> GetByIdAsync(Guid id)
    {
        return await validationRuleRepository.EnsureExistsAsync(id);
    }

    public async Task<ValidationRule> UpdateAsync(Guid id, UpdateValidationRuleDto dto)
    {
        var rule = await validationRuleRepository.EnsureExistsAsync(id);

        if (dto.Name != null)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Rule name cannot be empty");

            rule.Name = dto.Name.Trim();
        }

        if (dto.Description != null)
            rule.Description = dto.Description;

        if (dto.IsEnabled != null)
            rule.IsEnabled = dto.IsEnabled.Value;

        await validationRuleRepository.UpdateAsync(rule);
        await validationRuleRepository.SaveChangesAsync();

        return rule;
    }
}
