namespace FinTracker.Domain.Dtos.TransactionItems;

public class TransactionItemDto
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public Guid? CategoryId { get; set; }
}
