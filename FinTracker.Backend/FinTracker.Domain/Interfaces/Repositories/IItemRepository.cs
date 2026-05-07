using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IItemRepository : IRepository<TransactionItem>
{
    Task<IEnumerable<TransactionItem>> GetAllByTransactionIdAsync(Guid transactionId);
}
