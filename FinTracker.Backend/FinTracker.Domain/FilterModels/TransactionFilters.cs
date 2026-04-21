
namespace FinTracker.Domain.FilterModels;

public class TransactionFilters
{
    public Range<DateTime>? DateFilter { get; set; }
    public Range<decimal>? AmountFilter { get; set; }
    public string[]? CategoryFilter { get; set; }
    public string[]? TypeFilter { get; set; }
    public string[]? ScopeFilter { get; set; }
}
