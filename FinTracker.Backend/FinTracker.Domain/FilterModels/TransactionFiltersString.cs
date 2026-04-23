
namespace FinTracker.Domain.FilterModels;

public class TransactionFiltersString
{
    public Range<DateTime>? DateFilter { get; set; }
    public Range<decimal>? AmountFilter { get; set; }
    public List<string>? CategoryFilter { get; set; }
    public List<string>? TypeFilter { get; set; }
    public List<string>? ScopeFilter { get; set; }
}
