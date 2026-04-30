
namespace FinTracker.Domain.Models;

public class Scope
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    //public string? Description { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = [];
}