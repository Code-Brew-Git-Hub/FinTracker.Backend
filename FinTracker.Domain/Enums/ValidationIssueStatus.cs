
namespace FinTracker.Domain.Enums;

/// <summary>
/// Статус обработки найденной проблемы валидации
/// </summary>
public enum ValidationIssueStatus
{
    /// <summary>
    /// Проблема найдена и ещё не обработана
    /// </summary>
    New,
    /// <summary>
    /// Пользователь подтвердил, что требуется исправление
    /// </summary>
    Confirmed,
    /// <summary>
    /// Пользователь отклонил предложенное исправление
    /// </summary>
    Rejected,
    /// <summary>
    /// Проблема обработана
    /// </summary>
    Resolved
}
