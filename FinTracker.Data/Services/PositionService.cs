using FinTracker.Domain.Dtos.Positions;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class PositionService(
    IPositionRepository itemRepository,
    ITransactionRepository transactionRepository) : IPositionService
{
    public async Task<Position> CreateAsync(Guid transactionId, CreatePositionDto dto)
    {
        _ = await transactionRepository.EnsureExistsAsync(transactionId);

        var itemId = Guid.NewGuid();
        var item = new Position
        {
            Id = itemId,
            Name = dto.Name,
            Amount = dto.Amount,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice,
            Comment = dto.Comment,
            IsDeleted = false,
            TransactionId = transactionId,
            CategoryId = dto.CategoryId,
            PositionTags = (dto.TagIds ?? [])
                .Select(tagId => new PositionTag
                {
                    PositionId = itemId,
                    TagId = tagId
                })
                .ToList()
        };

        await itemRepository.AddAsync(item);
        await UpdateHasPositionsAsync(transactionId, hasPositions: true);
        await itemRepository.SaveChangesAsync();

        return await itemRepository.EnsureExistsAsync(item.Id);
    }

    public async Task DeleteAsync(Guid transactionId, Guid itemId)
    {
        var item = await itemRepository.EnsureExistsAsync(itemId);

        if (item.TransactionId != transactionId)
            throw new ArgumentException($"Item {itemId} does not belong to transaction {transactionId}");

        var activePositions = await itemRepository.GetAllByTransactionIdAsync(transactionId);
        var hasActivePositions = activePositions.Count > 1;

        item.IsDeleted = true;
        await itemRepository.UpdateAsync(item);
        await UpdateHasPositionsAsync(transactionId, hasActivePositions);
        await itemRepository.SaveChangesAsync();
    }

    public async Task<List<Position>> GetAllAsync(Guid transactionId)
    {
        _ = await transactionRepository.EnsureExistsAsync(transactionId);

        return await itemRepository.GetAllByTransactionIdAsync(transactionId);
    }

    public async Task<Position> UpdateAsync(Guid transactionId, Guid itemId, UpdatePositionDto dto)
    {
        _ = await transactionRepository.EnsureExistsAsync(transactionId);

        var item = await itemRepository.EnsureExistsAsync(itemId);

        if (item.TransactionId != transactionId)
            throw new ArgumentException($"Item {itemId} does not belong to transaction {transactionId}");

        if (dto.Name != null)
            item.Name = dto.Name;

        if (dto.Amount != null)
            item.Amount = dto.Amount.Value;

        if (dto.Quantity != null)
            item.Quantity = dto.Quantity;

        if (dto.UnitPrice != null)
            item.UnitPrice = dto.UnitPrice;

        if (dto.Comment != null)
            item.Comment = dto.Comment;

        if (dto.CategoryId != null)
            item.CategoryId = dto.CategoryId;

        if (dto.ReplaceTagIds != null)
        {
            item.PositionTags = dto.ReplaceTagIds
                .Select(tagId => new PositionTag
                {
                    PositionId = item.Id,
                    TagId = tagId
                })
                .ToList();
        }

        await itemRepository.UpdateAsync(item);
        await itemRepository.SaveChangesAsync();

        return await itemRepository.EnsureExistsAsync(item.Id);
    }

    private async Task UpdateHasPositionsAsync(Guid transactionId, bool hasPositions)
    {
        var transaction = await transactionRepository.EnsureExistsAsync(transactionId);
        transaction.HasPositions = hasPositions;
        await transactionRepository.UpdateAsync(transaction);
    }
}
