using FinTracker.Data.Repositories;
using FinTracker.Domain.Enums;
using FinTracker.Domain.FilterModels;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task CreateAsync(DateTime date, decimal amount, string currency, CategoryEnum category, string description, 
        TypeEnum type, Scope? scope, string comment, bool isDeleted,/* Card? from, Card? to, */
        CancellationToken cancellationToken = default)
    {
        var transaction = new Transaction
        {
            Date = date,
            Amount = amount,
            Currency = currency,
            Category = category,
            Description = description,
            Type = type,
            Scope = scope,
            Comment = comment,
            IsDeleted = isDeleted/*,
            From = from,
            To = to*/
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
