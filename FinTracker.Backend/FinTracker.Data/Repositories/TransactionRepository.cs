using FinTracker.Domain.FilterModels;
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

        public async Task<Transaction?> GetByIdAsync(int id, bool hideDeleted)
        {
            return context.Transactions.AsQueryable().Where(t => t.Id == id).Where(t => !hideDeleted || !t.IsDeleted).FirstOrDefault();
        }

        public async Task<List<Transaction>> GetAllAsync(bool hideDeleted)
        {
            return context.Transactions.AsQueryable().Where(t => !hideDeleted || !t.IsDeleted).ToList();
        }

        public async Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            var oldTransaction = await GetByIdAsync(transaction.Id, false);

            if (oldTransaction == null)
                throw new Exception("Такой транзакции не существует");

            oldTransaction.Date = transaction.Date;
            oldTransaction.Amount = transaction.Amount;
            oldTransaction.Currency = transaction.Currency;
            oldTransaction.Category = transaction.Category;
            oldTransaction.Description = transaction.Description;
            oldTransaction.Type = transaction.Type;
            oldTransaction.Scope = transaction.Scope;            
            oldTransaction.Comment = transaction.Comment;
            oldTransaction.IsDeleted = transaction.IsDeleted;
            //oldTransaction.From = transaction.From;
            //oldTransaction.To = transaction.To;            

            await context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetByFiltersAsync(TransactionFilters filters, bool hideDeleted)
        {
            //var query = context.Transactions.AsQueryable().Where(t => !hideDeleted || !t.IsDeleted);

            //if (filters.DateFilter != null && filters.DateFilter.Any())
            //    query = query.Where(t => filters.DateFilter.Contains(t.Date));

            //if (filters.AmountFilter != null && filters.AmountFilter.Any())
            //    query = query.Where(t => filters.AmountFilter.Contains(t.Amount));

            //if (filters.CategoryFilter != null && filters.CategoryFilter.Any())
            //    query = query.Where(t => filters.CategoryFilter.Contains(t.Category));

            //if (filters.TypeFilter != null && filters.TypeFilter.Any())
            //    query = query.Where(t => filters.TypeFilter.Contains(t.Type));

            //return await query.ToListAsync();

            throw new NotImplementedException();
        }
    }
}
