using FinTracker.Domain.Dtos.TransactionItems;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ItemService : IItemService
{
    public Task<TransactionItem> CreateAsync(Guid transactionId, CreateTransactionItemDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid transactionId, Guid itemId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TransactionItem>> GetAllAsync(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionItem> UpdateAsync(Guid transactionId, Guid itemId, UpdateTransactionItemDto dto)
    {
        throw new NotImplementedException();
    }
}
