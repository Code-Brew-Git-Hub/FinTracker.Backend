using FinTracker.Domain.Dtos.Categories;
using FinTracker.Domain.Dtos.Import;
using FinTracker.Domain.Dtos.Transactions;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;
using FinTracker.Parser;
using Microsoft.Extensions.Caching.Memory;

namespace FinTracker.Data.Services;

public class ImportService(TransactionParser parser,
    ITransactionRepository transactionRepository,
    ICategoryRepository categoryRepository,
    IMemoryCache memoryCache) : IImportService
{
    private static readonly MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromHours(1))  // Сохраняем в кэш на 1 час
        .SetPriority(CacheItemPriority.Normal);

    public async Task<ImportResultDto> ImportAsync(StreamReader reader, string filename)
    {
        var parseResult = await parser.Parse(reader, filename);

        var importedCount = 0;
        var incomeCount = 0;
        var expenseCount = 0;
        var categories = new Dictionary<string, int>();
        var savedTransactions = new List<TransactionPreviewDto>();
        var minDate = DateTime.MaxValue;
        var maxDate = DateTime.MinValue;

        if (parseResult.Errors.Any())
            throw new ArgumentException(parseResult.Errors.First().Reason);

        foreach (var p in parseResult.Transactions)
        {
            importedCount++;

            if (p.Amount < 0)
                expenseCount++;
            else
                incomeCount++;

            if (p.Date < minDate)
                minDate = p.Date;
            if (p.Date > maxDate)
                maxDate = p.Date;

            var categoryName = p.CategoryName;
            if (categories.ContainsKey(categoryName))
                categories[categoryName]++;
            else
                categories[categoryName] = 1;

            if (!memoryCache.TryGetValue(categoryName, out Category category))
            {
                category = await categoryRepository.GetByNameAsync(categoryName);

                if (category == null)
                {
                    category = new Category { Id = Guid.NewGuid(), Name = categoryName };
                    await categoryRepository.AddAsync(category);
                    await categoryRepository.SaveChangesAsync();
                }

                memoryCache.Set(categoryName, category, cacheEntryOptions);
            }

            var newTransaction = new Transaction
            {
                Id = Guid.NewGuid(),
                DateUtc = p.Date.ToUniversalTime(),
                Amount = p.Amount,
                Currency = p.Currency,
                Description = p.Description,
                Type = p.Amount < 0 ? TransactionType.Expense : TransactionType.Income,
                CategoryId = category.Id,
                Category = category,
                IsDeleted = false
            };

            await transactionRepository.AddAsync(newTransaction);

            if (importedCount % 100 == 0)
                await transactionRepository.SaveChangesAsync();

            if (savedTransactions.Count < 5)
                savedTransactions.Add(new TransactionPreviewDto
                {
                    Amount = newTransaction.Amount,
                    DateUtc = newTransaction.DateUtc,
                    Description = newTransaction.Description,
                    Category = categoryName
                });
        }

        await transactionRepository.SaveChangesAsync();

        return new ImportResultDto
        {
            Total = importedCount + parseResult.Errors.Count,
            Imported = importedCount,
            Errors = parseResult.Errors.Select(e => new ImportErrorDto
            {
                Row = e.Row,
                Reason = e.Reason
            }).ToList(),
            Categories = categories
                .Select(c => new CategoryImportStatDto { Name = c.Key, Count = c.Value })
                .OrderByDescending(c => c.Count)
                .ToList(),
            Period = importedCount > 0 ? new DateRangeDto() 
            { 
                From = minDate, 
                To = maxDate 
            } : null,
            IncomeCount = incomeCount,
            ExpenseCount = expenseCount,
            Preview = savedTransactions
        };
    }
}
