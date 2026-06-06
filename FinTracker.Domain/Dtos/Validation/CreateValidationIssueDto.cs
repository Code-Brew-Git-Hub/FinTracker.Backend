namespace FinTracker.Domain.Dtos.Validation;

public class CreateValidationIssueDto
{
    public Guid RuleId { get; set; }
    public List<Guid> TransactionIds { get; set; } = [];
    public string? Comment { get; set; }
}
