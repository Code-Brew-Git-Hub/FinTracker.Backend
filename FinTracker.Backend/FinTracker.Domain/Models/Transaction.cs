using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

public class Transaction
{
    // Данные от банка
    public int Id { get; set; }  // Id транзакции
    public DateTime Date { get; set; }  // Дата платежа (11.02.2025 11:46:53 | 24.03.2025)
    public decimal Amount { get; set; }  // Сумма транзакции (1500 | 124,12)
    public string Currency { get; set; } = string.Empty; // Валюта транзакции (например RUB, USD)
    public CategoryEnum Category { get; set; } // Категория (CategoryEnum.Transfer)
    public string Description { get; set; } = string.Empty; // Описание (Между счетами)
    public TypeEnum Type { get; set; }  // Тип (expense / income)
    // Данные от пользователя
    public Scope? Scope { get; set; }  // Группировка (день рождение Михалыча)
    public string Comment { get; set; } = string.Empty; // Комментарий пользователя
    public bool IsDeleted { get; set; } // Признак soft delete
    // В разработке
    //public Card? From { get; set; }  // С какого счета перевели
    //public Card? To { get; set; }  // На какой счет перевели
}