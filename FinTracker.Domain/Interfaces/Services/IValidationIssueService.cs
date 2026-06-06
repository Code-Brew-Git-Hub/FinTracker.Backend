using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Domain.Interfaces.Services;

public interface IValidationIssueService
{
    Task<List<ValidationIssue>> GetFilteredAsync(ValidationIssueFilter filter);
    Task<ValidationIssue> GetByIdAsync(Guid id);
    Task<ValidationIssue> CreateAsync(CreateValidationIssueDto dto);
    Task<ValidationIssue> UpdateAsync(Guid id, UpdateValidationIssueDto dto);
    Task<ValidationIssue> ConfirmAsync(Guid id, ConfirmValidationIssueDto dto);
    Task<ValidationIssue> RejectAsync(Guid id, RejectValidationIssueDto dto);
}
