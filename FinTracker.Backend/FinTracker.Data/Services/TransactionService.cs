
using FinTracker.Data.Repositories;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task CreateAsync(DateTime date, decimal amount, string currency, string description, 
        string category, TransactionType type, SourceType source, string comment, bool isDeleted, 
        CancellationToken cancellationToken = default)
    {
        var transaction = new Transaction
        {
            Date = date,
            Amount = amount,
            Currency = currency,
            Description = description,
            Category = category,
            Type = type,
            Source = source,
            Comment = comment,
            IsDeleted = isDeleted
        };

        await transactionRepository.AddAsync(transaction, cancellationToken);
    }

    public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
    {
        await transactionRepository.AddAsync(transaction, cancellationToken);
    }

    public async Task<List<Transaction>> GetAllAsync()
    {
        return await transactionRepository.GetAllAsync();
    }

    public async Task<Transaction?> GetByIdAsync(int id)
    {
        return await transactionRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default)
    {
        await transactionRepository.UpdateAsync(transaction, cancellationToken);
    }
}
