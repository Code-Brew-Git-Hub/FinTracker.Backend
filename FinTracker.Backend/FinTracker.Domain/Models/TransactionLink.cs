using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

public class TransactionLink
{
    public Guid Id { get; set; }
    public TransactionLinkType Type { get; set; }
    public ICollection<TransactionLinkEntry> Entries { get; set; } = [];
}