using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Models;

public class Transaction
{
    // Данные от банка
    public Guid Id { get; set; }  // Id транзакции
    public decimal Amount { get; set; }  // Сумма транзакции (1500 | 124,12)
    public string Currency { get; set; } = string.Empty; // Валюта транзакции (например RUB, USD)
    public DateTime Date { get; set; }  // Дата платежа (11.02.2025 11:46:53 | 24.03.2025)
    public string? Description { get; set; } // Описание (Между счетами)
    public string? Comment { get; set; } // Комментарий пользователя
    public TransactionType Type { get; set; }  // Тип (expense / income)
    public bool IsDeleted { get; set; } // Признак soft delete

    // Foreign Keys
    public Guid CategoryId { get; set; }  // id категории
    public Guid? ScopeId { get; set; }  // id группы
        
    // Navigation
    public Category Category { get; set; }  // Категория
    public Scope? Scope { get; set; }  // Группа

    public ICollection<TransactionTag> TransactionTags { get; set; } = [];  // Теги
    //public ICollection<TransactionItem> Items { get; set; } = [];  // Элементы транзакции (хлеб, колбаса, вода)



    
    //public ICollection<TransactionLinkEntry> LinkEntries { get; set; } = [];
}