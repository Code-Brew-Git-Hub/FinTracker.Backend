using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models.ModelsToHelp;

public class TransactionFilter
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public decimal? AmountMin { get; set; }
    public decimal? AmountMax { get; set; }
    public Guid? CategoryId { get; set; }
    public TransactionType? Type { get; set; }
    public List<Guid>? TagIds { get; set; }
    public Guid? ScopeId { get; set; }
    public string? Search { get; set; }  // Поиск в описании
    public bool ExcludeScopes { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
