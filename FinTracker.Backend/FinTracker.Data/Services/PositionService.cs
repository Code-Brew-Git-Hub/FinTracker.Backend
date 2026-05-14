using FinTracker.Domain.Dtos.Positions;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class PositionService(IPositionRepository itemRepository, ITransactionRepository transactionRepository) : IPositionService
{
    public async Task<Position> CreateAsync(Guid transactionId, CreatePositionDto dto)
    {
        _ = await transactionRepository.GetByIdAsync(transactionId)
            ?? throw new KeyNotFoundException($"Transaction {transactionId} not found");

        await ValidateTotalAmount(transactionId, dto.Amount);

        var item = new Position
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Amount = dto.Amount,
            TransactionId = transactionId,
            CategoryId = dto.CategoryId
        };

        await itemRepository.AddAsync(item);
        await itemRepository.SaveChangesAsync();

        return item;
    }

    public async Task DeleteAsync(Guid transactionId, Guid itemId)
    {
        var item = await itemRepository.GetByIdAsync(itemId)
            ?? throw new KeyNotFoundException($"Item {itemId} not found");

        if (item.TransactionId != transactionId)
            throw new ArgumentException($"Item {itemId} does not belong to transaction {transactionId}");

        await itemRepository.DeleteAsync(itemId);
        await itemRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<Position>> GetAllAsync(Guid transactionId)
    {
        _ = await transactionRepository.GetByIdAsync(transactionId)
            ?? throw new KeyNotFoundException($"Transaction {transactionId} not found");

        return await itemRepository.GetAllByTransactionIdAsync(transactionId);
    }

    public async Task<Position> UpdateAsync(Guid transactionId, Guid itemId, UpdatePositionDto dto)
    {
        _ = await transactionRepository.GetByIdAsync(transactionId)
            ?? throw new KeyNotFoundException($"Transaction {transactionId} not found");

        var item = await itemRepository.GetByIdAsync(itemId)
            ?? throw new KeyNotFoundException($"Item {itemId} not found");

        // Проверяем что позиция принадлежит этой транзакции
        if (item.TransactionId != transactionId)
            throw new ArgumentException($"Item {itemId} does not belong to transaction {transactionId}");

        if (dto.Name != null)
            item.Name = dto.Name;

        if (dto.Amount != null)
        {
            await ValidateTotalAmount(transactionId, dto.Amount.Value, excludeItemId: itemId);
            item.Amount = dto.Amount.Value;
        }

        if (dto.CategoryId != null)
            item.CategoryId = dto.CategoryId;

        await itemRepository.UpdateAsync(item);
        await itemRepository.SaveChangesAsync();

        return item;
    }

    private async Task ValidateTotalAmount(Guid transactionId, decimal newItemAmount, Guid? excludeItemId = null)
    {
        var transaction = await transactionRepository.GetByIdAsync(transactionId)
            ?? throw new KeyNotFoundException($"Transaction {transactionId} not found");

        var existingItems = await itemRepository.GetAllByTransactionIdAsync(transactionId);

        // При обновлении исключаем старую сумму редактируемого item
        var currentTotal = existingItems
            .Where(i => i.Id != excludeItemId)
            .Sum(i => i.Amount);

        if (currentTotal + newItemAmount > Math.Abs(transaction.Amount))
            throw new ArgumentException(
                $"Сумма позиций ({currentTotal + newItemAmount}) превышает сумму транзакции ({Math.Abs(transaction.Amount)})");
    }
}
