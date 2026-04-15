using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

public class Transaction
{
    public int Id { get; set; }  // Id транзакции
    public DateTime Date { get; set; }  // Дата платежа
    public decimal Amount { get; set; }  // Сумма транзакции
    public CurrencyType Currency { get; set; }  // Валюта транзакции (например RUB, USD)
    public string Description { get; set; }  // Описание (банка)
    public string Category { get; set; }  // Категория
    public TransactionType Type { get; set; }  // Тип (expense / income / transfer)
    public SourceType Source { get; set; }  // Источник (csv / manual)
    public string Comment { get; set; }  // Комментарий пользователя
    public bool IsDeleted { get; set; } // Признак soft delete
}