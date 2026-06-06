namespace FinTracker.Domain.Dtos.Import;

public class ImportValidationSummaryDto
{
    public int FoundGroups { get; set; }
    public int CreatedIssues { get; set; }
    public int SkippedGroups { get; set; }
    public List<Guid> CreatedIssueIds { get; set; } = [];
}
