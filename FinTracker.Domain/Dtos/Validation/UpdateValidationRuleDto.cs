namespace FinTracker.Domain.Dtos.Validation;

public class UpdateValidationRuleDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsEnabled { get; set; }
}
