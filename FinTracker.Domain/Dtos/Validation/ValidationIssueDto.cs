namespace FinTracker.Domain.Dtos.Validation;

public class ValidationIssueDto
{
    public Guid Id { get; set; }
    public Guid RuleId { get; set; }
    public string RuleName { get; set; } = string.Empty;
    public List<Guid> TransactionIds { get; set; } = [];
    public string Status { get; set; } = string.Empty;
    public string? Comment { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
