
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

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return context.Transactions.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return context.Transactions.ToList();
        }

        public async Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            var oldTransaction = await GetByIdAsync(transaction.Id);

            if (oldTransaction == null)
                throw new Exception("Такой транзакции не существует");

            oldTransaction.Date = transaction.Date;
            oldTransaction.Category = transaction.Category;
            oldTransaction.Currency = transaction.Currency;
            oldTransaction.Source = transaction.Source;
            oldTransaction.Amount = transaction.Amount;
            oldTransaction.Comment = transaction.Comment;
            oldTransaction.Description = transaction.Description;
            oldTransaction.Type = transaction.Type;

            await context.SaveChangesAsync();
        }
    }
}
