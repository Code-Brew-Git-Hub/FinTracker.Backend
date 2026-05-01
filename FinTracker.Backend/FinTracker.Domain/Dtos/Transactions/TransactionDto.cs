using FinTracker.Domain.Dtos.Categories;
using FinTracker.Domain.Dtos.Scopes;
using FinTracker.Domain.Dtos.Tags;
using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Dtos.Transactions;

public class TransactionDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public TransactionType Type { get; set; }
    public bool IsDeleted { get; set; }

    public CategoryDto Category { get; set; }
    public ScopeDto? Scope { get; set; }
    public List<TagDto> Tags { get; set; } = [];
}
