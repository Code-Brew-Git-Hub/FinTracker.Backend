using FinTracker.Domain.Dtos.Transactions;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using FinTracker.Domain.Models.ModelsToHelp;

namespace FinTracker.Data.Services;

public class TransactionService(ITransactionRepository transactionRepository,
    ICategoryRepository categoryRepository, IScopeRepository scopeRepository) : ITransactionService
{
    public Task BulkUpdateAsync(IEnumerable<Guid> ids, BulkUpdateData data)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> CreateAsync(CreateTransactionDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> UpdateAsync(Guid id, UpdateTransactionDto dto)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Transaction>> ITransactionService.GetFilteredAsync(TransactionFilter filter)
    {
        throw new NotImplementedException();
    }
}
