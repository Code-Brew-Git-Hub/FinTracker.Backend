using FinTracker.Data.Repositories;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class ScopeService(IScopeRepository scopeRepository,
    ITransactionRepository transactionRepository) : IScopeService
{
    public async Task<Scope> CreateAsync(string name)
    {
        var existing = await scopeRepository.GetByNameAsync(name);
        if (existing != null)
            throw new ArgumentException($"Scope '{name}' already exists");

        var newScope = new Scope()
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        await scopeRepository.AddAsync(newScope);
        await scopeRepository.SaveChangesAsync();

        return newScope;
    }

    public async Task DeleteAsync(Guid id)
    {
        await scopeRepository.DeleteAsync(id);
        await scopeRepository.SaveChangesAsync();
    }

    public async Task<List<Scope>> GetAllAsync()
    {
        return await scopeRepository.GetAllAsync();
    }

    public async Task<Scope> GetByIdAsync(Guid id)
    {
        return await scopeRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Scope {id} not found");
    }

    public async Task<List<Transaction>> GetTransactionsAsync(Guid scopeId)
    {
        var scope = await scopeRepository.GetByIdAsync(scopeId)
            ?? throw new KeyNotFoundException($"Scope {scopeId} not found");

        return await transactionRepository.GetByScopeIdAsync(scopeId);
    }

    public async Task<Scope> UpdateAsync(Guid id, string name)
    {
        var scope = await scopeRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Scope {id} not found");

        scope.Name = name;

        await scopeRepository.UpdateAsync(scope);
        await scopeRepository.SaveChangesAsync();

        return scope;
    }
}
