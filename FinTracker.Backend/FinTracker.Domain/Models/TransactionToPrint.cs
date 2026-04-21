
namespace FinTracker.Domain.Models;

public class TransactionToPrint
{
    public int Id { get; set; }
    public string Date { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    
    public string? Scope { get; set; }
    public string Comment { get; set; }
    public bool IsDeleted { get; set; }
    // В разработке
    //public string? from { get; set; }
    //public string? to { get; set; }
}
