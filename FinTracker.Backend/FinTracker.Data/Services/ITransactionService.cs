
using FinTracker.Domain.Enums;

namespace FinTracker.Data.Services;

public interface ITransactionService
{
    Task CreateAsync(DateTime date, decimal amount, CurrencyType currency, string description,
        string category, TransactionType type, SourceType source, string comment, bool isDeleted, 
        CancellationToken cancellationToken = default);
}
