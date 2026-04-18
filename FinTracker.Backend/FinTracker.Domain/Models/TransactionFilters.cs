using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

public class TransactionFilters
{
    public DateTime[]? DateFilter { get; set; }
    public decimal[]? AmountFilter { get; set; }
    public string[]? CategoryFilter { get; set; }
    public TransactionType[]? TypeFilter { get; set; }
}
