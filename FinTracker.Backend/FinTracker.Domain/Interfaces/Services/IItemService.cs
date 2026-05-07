using FinTracker.Domain.Dtos.TransactionItems;
using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Services;

public interface IItemService
{
    Task<IEnumerable<TransactionItem>> GetAllAsync(Guid transactionId);
    Task<TransactionItem> CreateAsync(Guid transactionId, CreateTransactionItemDto dto);
    Task<TransactionItem> UpdateAsync(Guid transactionId, Guid itemId, UpdateTransactionItemDto dto);
    Task DeleteAsync(Guid transactionId, Guid itemId);
}
