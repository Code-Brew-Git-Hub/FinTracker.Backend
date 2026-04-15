
namespace FinTracker.Domain.Enums;

/// <summary>
/// Тип транзакции: расход, доход, перевод
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Расход
    /// </summary>
    Expense,
    /// <summary>
    /// Доход
    /// </summary>
    Income,
    /// <summary>
    /// Перевод
    /// </summary>
    Transfer
}
