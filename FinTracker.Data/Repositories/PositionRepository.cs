using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Data.Repositories;

public class PositionRepository(AppDbContext context) : IPositionRepository
{
    public async Task AddAsync(Position entity)
    {
        await context.TransactionItems.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await GetByIdAsync(id, includeDeleted: true);
        if (item != null)
            context.TransactionItems.Remove(item);
    }

    public async Task<List<Position>> GetAllAsync()
    {
        return await context.TransactionItems
            .Where(p => !p.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<Position>> GetAllByTransactionIdAsync(Guid transactionId)
    {
        return await context.TransactionItems
            .Include(p => p.Category)
            .Include(p => p.PositionTags)
                .ThenInclude(pt => pt.Tag)
            .Where(p => p.TransactionId == transactionId && !p.IsDeleted)
            .ToListAsync();
    }

    public async Task<bool> HasActivePositionsAsync(Guid transactionId)
    {
        return await context.TransactionItems
            .AnyAsync(p => p.TransactionId == transactionId && !p.IsDeleted);
    }

    public async Task<Position?> GetByIdAsync(Guid id)
    {
        return await GetByIdAsync(id, includeDeleted: false);
    }

    public async Task<Position?> GetByIdAsync(Guid id, bool includeDeleted)
    {
        var query = context.TransactionItems
            .Include(p => p.Category)
            .Include(p => p.PositionTags)
                .ThenInclude(pt => pt.Tag)
            .AsQueryable();

        if (!includeDeleted)
            query = query.Where(p => !p.IsDeleted);

        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Position entity)
    {
        context.TransactionItems.Update(entity);
    }
}
