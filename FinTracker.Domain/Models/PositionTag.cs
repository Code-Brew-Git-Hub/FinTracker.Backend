namespace FinTracker.Domain.Models;

/// <summary>
/// Связь Many-to-many: Position &lt;-&gt; Tag
/// </summary>
public class PositionTag
{
    /// <summary>
    /// Id позиции
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// Позиция
    /// </summary>
    public Position Position { get; set; } = null!;

    /// <summary>
    /// Id тега
    /// </summary>
    public Guid TagId { get; set; }
    /// <summary>
    /// Тег
    /// </summary>
    public Tag Tag { get; set; } = null!;
}
