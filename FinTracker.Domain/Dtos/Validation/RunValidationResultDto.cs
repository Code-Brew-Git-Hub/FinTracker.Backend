namespace FinTracker.Domain.Dtos.Validation;

public class RunValidationResultDto
{
    public Guid RuleId { get; set; }
    public int FoundGroups { get; set; }
    public int CreatedIssues { get; set; }
    public int SkippedGroups { get; set; }
    public List<Guid> CreatedIssueIds { get; set; } = [];
}
