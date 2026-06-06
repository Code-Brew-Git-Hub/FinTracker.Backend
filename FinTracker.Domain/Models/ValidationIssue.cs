using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

/// <summary>
/// Найденная потенциальная проблема при проверке транзакций
/// </summary>
public class ValidationIssue
{
    /// <summary>
    /// Id проблемы
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Id правила, по которому найдена проблема
    /// </summary>
    public Guid RuleId { get; set; }
    /// <summary>
    /// Статус обработки проблемы
    /// </summary>
    public ValidationIssueStatus Status { get; set; }
    /// <summary>
    /// Комментарий пользователя или системы
    /// </summary>
    public string? Comment { get; set; }
    /// <summary>
    /// Дата и время обнаружения проблемы (UTC)
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Правило проверки
    /// </summary>
    public ValidationRule Rule { get; set; } = null!;
    /// <summary>
    /// Транзакции, участвующие в проблеме
    /// </summary>
    public ICollection<ValidationIssueTransaction> Transactions { get; set; } = [];
}
