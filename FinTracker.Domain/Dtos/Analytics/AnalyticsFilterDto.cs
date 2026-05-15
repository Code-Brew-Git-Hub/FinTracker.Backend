namespace FinTracker.Domain.Dtos.Analytics;

public class AnalyticsFilterDto
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<Guid>? ExcludeScopeIds { get; set; }
    public bool ExcludeTransfers { get; set; } = true;
    public bool ExcludeCompensations { get; set; } = true;
}
