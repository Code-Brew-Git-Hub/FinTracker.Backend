using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models.ModelsToHelp;

/// <summary>
/// Фильтрация найденных проблем валидации
/// </summary>
public class ValidationIssueFilter
{
    /// <summary>
    /// По правилу: id правила проверки
    /// </summary>
    public Guid? RuleId { get; set; }
    /// <summary>
    /// По статусу обработки проблемы
    /// </summary>
    public ValidationIssueStatus? Status { get; set; }
}
