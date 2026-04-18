using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

public class Transaction
{
    public int Id { get; set; }  // Id транзакции
    public DateTime Date { get; set; }  // Дата платежа
    public decimal Amount { get; set; }  // Сумма транзакции
    public string Currency { get; set; } = string.Empty; // Валюта транзакции (например RUB, USD)
    public string Description { get; set; } = string.Empty; // Описание (банка)
    public string Category { get; set; } = string.Empty; // Категория
    public TransactionType Type { get; set; }  // Тип (expense / income / transfer)
    public SourceType Source { get; set; }  // Источник (csv / manual)
    public string Comment { get; set; } = string.Empty; // Комментарий пользователя
    public bool IsDeleted { get; set; } // Признак soft delete
}