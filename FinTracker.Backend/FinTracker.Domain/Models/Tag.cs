
namespace FinTracker.Domain.Models;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<TransactionTag> TransactionTags { get; set; } = [];
}