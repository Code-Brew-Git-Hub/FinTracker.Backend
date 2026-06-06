namespace FinTracker.Domain.Models;

/// <summary>
/// Правило проверки транзакций на корректность
/// </summary>
public class ValidationRule
{
    /// <summary>
    /// Id правила
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Название правила
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Описание правила
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Признак активности правила
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Найденные проблемы по этому правилу
    /// </summary>
    public ICollection<ValidationIssue> Issues { get; set; } = [];
}
