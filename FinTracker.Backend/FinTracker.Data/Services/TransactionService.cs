using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class TransactionService(ITransactionRepository transactionRepository, 
    ICategoryRepository categoryRepository, IScopeRepository scopeRepository) : ITransactionService
{
    public async Task CreateAsync(decimal amount, string currency, DateTime date, string? description, 
        string? comment, Category category, Scope? scope, CancellationToken cancellationToken = default)
    {
        var transaction = new Transaction()
        {
            Id = Guid.NewGuid(),
            Amount = amount,
            Currency = currency,
            Date = date.ToUniversalTime(),
            Description = description,
            Comment = comment,
            Type = amount < 0 ? TransactionType.Expense : TransactionType.Income,
            IsDeleted = false,
            CategoryId = category.Id,
            ScopeId = scope?.Id,
            Category = category,
            Scope = scope
        };

        await transactionRepository.AddAsync(transaction);
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        var transaction =  await transactionRepository.GetByIdAsync(id);

        transaction?.Category = await categoryRepository.GetByIdAsync(transaction.CategoryId) 
            ?? throw new Exception("В транзакции не была указана категория");

        if (transaction != null && transaction.ScopeId is not null)
            transaction.Scope = await scopeRepository.GetByIdAsync((Guid)transaction.ScopeId);

        return transaction;
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        await transactionRepository.UpdateAsync(transaction);
    }
}
