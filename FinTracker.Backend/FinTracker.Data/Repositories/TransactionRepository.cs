using FinTracker.Domain.FilterModels;
using FinTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
            var query = context.Transactions.AsQueryable().Where(t => !hideDeleted || !t.IsDeleted);

            // Date filter (range)
            if (filters.DateFilter != null)
                query = query.Where(t => filters.DateFilter.From <= t.Date && t.Date <= filters.DateFilter.To);

            // Amount filter (range)
            if (filters.AmountFilter != null)
                query = query.Where(t => filters.AmountFilter.From <= t.Amount && t.Amount <= filters.AmountFilter.To);

            // Category filter (list)
            if (filters.CategoryFilter != null && filters.CategoryFilter.Any())
                query = query.Where(t => filters.CategoryFilter.Contains(t.Category));

            // Type filter (list)
            if (filters.TypeFilter != null && filters.TypeFilter.Any())
                query = query.Where(t => filters.TypeFilter.Contains(t.Type));

            // Scope filter (list)
            if (filters.ScopeFilter != null && filters.ScopeFilter.Any())
                query = query.Where(t => t.Scope != null && filters.ScopeFilter.Contains(t.Scope));

            return await query.ToListAsync<Transaction>();
        }
    }
}
