
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface ITransactionService
{
    Task CreateAsync(DateTime date, decimal amount, CurrencyType currency, string description,
        string category, TransactionType type, SourceType source, string comment, bool isDeleted, 
        CancellationToken cancellationToken = default);

    Task<Transaction> GetById(int id);
    Task<List<Transaction>> GetAll();
}
