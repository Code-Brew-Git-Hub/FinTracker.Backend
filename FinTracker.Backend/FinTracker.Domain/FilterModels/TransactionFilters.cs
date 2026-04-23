
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;

namespace FinTracker.Domain.FilterModels;

public class TransactionFilters
{
    public Range<DateTime>? DateFilter { get; set; }
    public Range<decimal>? AmountFilter { get; set; }
    public List<CategoryEnum>? CategoryFilter { get; set; }
    public List<TypeEnum>? TypeFilter { get; set; }
    public List<Scope>? ScopeFilter { get; set; }
}
