namespace FinTracker.Domain.Models;

/// <summary>
/// Позиция транзакции
/// </summary>
public class Position
{
    /// <summary>
    /// Id позиции
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Название позиции
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Сумма позиции
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Количество единиц позиции
    /// </summary>
    public decimal? Quantity { get; set; }
    /// <summary>
    /// Цена за единицу
    /// </summary>
    public decimal? UnitPrice { get; set; }
    /// <summary>
    /// Дополнительное описание позиции
    /// </summary>
    public string? Comment { get; set; }
    /// <summary>
    /// Признак логического удаления
    /// </summary>
    public bool IsDeleted { get; set; }
    /// <summary>
    /// Id транзакции, в которой находится позиция
    /// </summary>
    public Guid TransactionId { get; set; }
    /// <summary>
    /// Транзакция, в которой находится позиция
    /// </summary>
    public Transaction Transaction { get; set; } = null!;
    /// <summary>
    /// Id категории, к которой относится позиция
    /// </summary>
    public Guid? CategoryId { get; set; }
    /// <summary>
    /// Категория, к которой относится позиция
    /// </summary>
    public Category? Category { get; set; }
    /// <summary>
    /// Теги позиции
    /// </summary>
    public ICollection<PositionTag> PositionTags { get; set; } = [];
}
