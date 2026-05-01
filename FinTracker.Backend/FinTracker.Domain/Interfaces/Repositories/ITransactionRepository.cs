using FinTracker.Domain.Dtos.Transactions;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetFilteredAsync(TransactionFilter filter);
    Task BulkUpdateAsync(BulkUpdateDto dto);
    Task<IEnumerable<Transaction>> GetByScopeIdAsync(Guid scopeId);
}
