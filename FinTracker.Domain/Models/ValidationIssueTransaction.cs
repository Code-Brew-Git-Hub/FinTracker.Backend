namespace FinTracker.Domain.Models;

/// <summary>
/// Связь найденной проблемы с транзакцией
/// </summary>
public class ValidationIssueTransaction
{
    /// <summary>
    /// Id проблемы
    /// </summary>
    public Guid ValidationIssueId { get; set; }
    /// <summary>
    /// Id транзакции
    /// </summary>
    public Guid TransactionId { get; set; }

    /// <summary>
    /// Проблема валидации
    /// </summary>
    public ValidationIssue Issue { get; set; } = null!;
    /// <summary>
    /// Транзакция
    /// </summary>
    public Transaction Transaction { get; set; } = null!;
}
