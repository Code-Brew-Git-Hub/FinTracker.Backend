using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task CreateAsync(DateTime date, decimal amount, string currency, Category category, string? description, 
        Scope? scope, string? comment, bool isDeleted,/* Card? from, Card? to, */
        CancellationToken cancellationToken = default)
    {
        var transaction = new Transaction
        {
            Date = date,
            Amount = amount,
            Currency = currency,
            Category = category,
            Description = description,
            Type = amount >= 0 ? TransactionType.Income : TransactionType.Expense,
            Scope = scope,
            Comment = comment,
            IsDeleted = isDeleted
        };

        await transactionRepository.AddAsync(transaction, cancellationToken);
    }
}
