using FinTracker.Domain.Dtos.Positions;
using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Services;

public interface IPositionService
{
    Task<IEnumerable<Position>> GetAllAsync(Guid transactionId);
    Task<Position> CreateAsync(Guid transactionId, CreatePositionDto dto);
    Task<Position> UpdateAsync(Guid transactionId, Guid itemId, UpdatePositionDto dto);
    Task DeleteAsync(Guid transactionId, Guid itemId);
}
