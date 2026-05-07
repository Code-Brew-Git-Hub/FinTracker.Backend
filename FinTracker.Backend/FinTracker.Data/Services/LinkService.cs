using FinTracker.Domain.Dtos.TransactionLinks;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;

namespace FinTracker.Data.Services;

public class LinkService : ILinkService
{
    public Task<TransactionLink> AddTransactionAsync(Guid linkId, Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionLink> CreateAsync(CreateTransactionLinkDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionLink> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTransactionAsync(Guid linkId, Guid transactionId)
    {
        throw new NotImplementedException();
    }
}
