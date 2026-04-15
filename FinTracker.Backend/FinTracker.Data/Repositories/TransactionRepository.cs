
using FinTracker.Domain.Models;

namespace FinTracker.Data.Repositories
{
    public class TransactionRepository(AppContext context) : ITransactionRepository
    {
        public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            await context.Transactions.AddAsync(transaction, cancellationToken);
            await context.SaveChangesAsync();
        }
    }
}
