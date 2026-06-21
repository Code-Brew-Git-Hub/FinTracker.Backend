namespace FinTracker.Domain.Dtos.Positions;

public class UpdatePositionDto
{
    public string? Name { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Quantity { get; set; }
    public decimal? UnitPrice { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Comment { get; set; }
    public List<Guid>? ReplaceTagIds { get; set; }
}
