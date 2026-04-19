
using FinTracker.Data.Repositories;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Transaction>> GetAllAsync(bool hideDeleted)
    {
        return await transactionRepository.GetAllAsync(hideDeleted);
    }

    public async Task<Transaction?> GetByIdAsync(int id, bool hideDeleted)
    {
        return await transactionRepository.GetByIdAsync(id, hideDeleted);
    }

    public async Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default)
    {
        await transactionRepository.UpdateAsync(transaction, cancellationToken);
    }

    public async Task<List<Transaction>> GetByFiltersAsync(TransactionFilters filters, bool hideDeleted)
    {
        return await transactionRepository.GetByFiltersAsync(filters, hideDeleted);
    }
}
