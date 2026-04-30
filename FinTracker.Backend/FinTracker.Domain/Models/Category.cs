
namespace FinTracker.Domain.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    /*
    // Иерархия (parent-child)
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category> Children { get; set; } = [];
    */

    // Navigation
    public ICollection<Transaction> Transactions { get; set; } = [];
    /*
    public ICollection<TransactionItem> Items { get; set; } = [];
    */
}
