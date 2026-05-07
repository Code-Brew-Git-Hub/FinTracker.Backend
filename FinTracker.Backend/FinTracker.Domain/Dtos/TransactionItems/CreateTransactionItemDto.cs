namespace FinTracker.Domain.Dtos.TransactionItems;

public class CreateTransactionItemDto
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public Guid? CategoryId { get; set; }
}
