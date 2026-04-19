
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public interface ITransactionService
{
    Task CreateAsync(DateTime date, decimal amount, string currency, string description,
        string category, TransactionType type, SourceType source, string comment, bool isDeleted,
        CancellationToken cancellationToken = default);
    Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
    Task<Transaction?> GetByIdAsync(int id, bool hideDeleted);
    Task<List<Transaction>> GetAllAsync(bool hideDeleted);
    Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default);
    Task<List<Transaction>> GetByFiltersAsync(TransactionFilters filters, bool hideDeleted);
}
