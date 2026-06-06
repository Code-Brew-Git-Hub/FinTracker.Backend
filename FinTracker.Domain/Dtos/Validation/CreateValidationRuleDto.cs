namespace FinTracker.Domain.Dtos.Validation;

public class CreateValidationRuleDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsEnabled { get; set; } = true;
}
