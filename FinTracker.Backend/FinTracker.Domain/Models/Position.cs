
namespace FinTracker.Domain.Models;

public class Position
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public Guid TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}