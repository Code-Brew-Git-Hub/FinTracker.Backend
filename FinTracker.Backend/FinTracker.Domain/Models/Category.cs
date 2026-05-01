
namespace FinTracker.Domain.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Navigation
    public ICollection<Transaction> Transactions { get; set; } = [];
    /*
    public ICollection<TransactionItem> Items { get; set; } = [];
    */
}
