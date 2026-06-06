namespace FinTracker.Domain.Dtos.Validation;

public class ValidationRuleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsEnabled { get; set; }
}
