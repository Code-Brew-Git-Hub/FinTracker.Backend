namespace FinTracker.Domain.Dtos.Transactions;

public class UpdateTransactionDto
{
    public decimal? Amount { get; set; }
    public string? Currency { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? ScopeId { get; set; }
    public List<Guid>? TagIds { get; set; }
}

