using FinTracker.Domain.Dtos.Validation;

namespace FinTracker.Domain.Interfaces.Services;

public interface IValidationService
{
    Task<RunValidationResultDto> RunIdenticalTransactionsAsync(Guid? ruleId = null);
}
