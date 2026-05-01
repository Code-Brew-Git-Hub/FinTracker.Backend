using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetFilteredAsync(TransactionFilter filter);
    Task BulkUpdateAsync(IEnumerable<Guid> ids, BulkUpdateData data);
    Task UpdateAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetByScopeIdAsync(Guid scopeId);
}
