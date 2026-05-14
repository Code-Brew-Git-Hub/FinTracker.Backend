using FinTracker.Domain.Models;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IPositionRepository : IRepository<Position>
{
    Task<IEnumerable<Position>> GetAllByTransactionIdAsync(Guid transactionId);
}
