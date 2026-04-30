
using FinTracker.Domain.Models;

namespace FinTracker.Domain.ModelsToPrint;

public class TransactionToPrint
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public string Type { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? ScopeId { get; set; }

    public ICollection<TransactionTag> TransactionTags { get; set; } = [];

    public TransactionToPrint(Transaction transaction)
    {
        Id = transaction.Id;
        Amount = transaction.Amount;
        Currency = transaction.Currency;
        Date = transaction.Date;
        Description = transaction.Description;
        Comment = transaction.Comment;
        Type = transaction.Type.ToString();
        IsDeleted = transaction.IsDeleted;
        CategoryId = transaction.CategoryId;
        ScopeId = transaction.ScopeId;
    }
}
