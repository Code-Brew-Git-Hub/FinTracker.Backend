using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class ItemRepository(AppDbContext context) : IItemRepository
{
    public async Task AddAsync(TransactionItem entity)
    {
        await context.TransactionItems.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
            context.TransactionItems.Remove(item);
    }

    public async Task<IEnumerable<TransactionItem>> GetAllAsync()
    {
        return await context.TransactionItems.ToListAsync();
    }

    public async Task<IEnumerable<TransactionItem>> GetAllByTransactionIdAsync(Guid transactionId)
    {
        return await context.TransactionItems
            .Include(ti => ti.Category)
            .Where(ti => ti.TransactionId == transactionId)
            .ToListAsync();
    }

    public async Task<TransactionItem?> GetByIdAsync(Guid id)
    {
        return await context.TransactionItems.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TransactionItem entity)
    {
        context.TransactionItems.Update(entity);
    }
}
