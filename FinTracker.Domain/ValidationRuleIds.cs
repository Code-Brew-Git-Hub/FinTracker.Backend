namespace FinTracker.Domain;

/// <summary>
/// Фиксированные идентификаторы предустановленных правил валидации (seed в БД).
/// Используются в коде для ссылки на конкретное правило без поиска по имени.
/// </summary>
public static class ValidationRuleIds
{
    /// <summary>
    /// Поиск полностью идентичных транзакций (дата, сумма, описание, валюта)
    /// </summary>
    public static readonly Guid IdenticalTransactions =
        new("a0000001-0000-4000-8000-000000000001");
}
