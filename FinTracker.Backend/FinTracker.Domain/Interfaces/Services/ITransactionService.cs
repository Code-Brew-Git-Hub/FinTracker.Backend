using FinTracker.Domain.Dtos.Transactions;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Data.Services;

public interface ITransactionService
{
    Task<Transaction> GetByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetFilteredAsync(TransactionFilter filter);
    Task<Transaction> CreateAsync(CreateTransactionDto dto);
    Task<Transaction> UpdateAsync(Guid id, UpdateTransactionDto dto);
    Task DeleteAsync(Guid id);
    Task BulkUpdateAsync(IEnumerable<Guid> ids, BulkUpdateData data);
}
