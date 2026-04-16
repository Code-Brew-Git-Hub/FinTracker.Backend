
using FinTracker.Data.Repositories;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task CreateAsync(DateTime date, decimal amount, CurrencyType currency, string description, 
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

    public async Task<List<Transaction>> GetAll()
    {
        return await transactionRepository.GetAll();
    }

    public async Task<Transaction> GetById(int id)
    {
        return await transactionRepository.GetById(id);
    }
}
