using FinTracker.Domain.Dtos.Tags;

namespace FinTracker.Domain.Dtos.Positions;

public class PositionDto
{
    public Guid Id { get; set; }
    public Guid TransactionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal? Quantity { get; set; }
    public decimal? UnitPrice { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Comment { get; set; }
    public List<TagDto> Tags { get; set; } = [];
}
