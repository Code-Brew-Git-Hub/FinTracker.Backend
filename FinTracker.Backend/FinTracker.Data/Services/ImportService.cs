using FinTracker.Domain.Dtos.Import;
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
        var parsedTransactionCount = 0;

        if (!parseResult.Transactions.Any() && parseResult.Errors.Any())
            throw new ArgumentException(parseResult.Errors.First().Reason);

        foreach (var p in parseResult.Transactions)
        {
            parsedTransactionCount++;

            var categoryName = p.CategoryName;

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

            await transactionRepository.AddAsync(new Transaction
            {
                Id = Guid.NewGuid(),
                Date = p.Date.ToUniversalTime(),
                Amount = p.Amount,
                Currency = p.Currency,
                Description = p.Description,
                Type = p.Amount < 0 ? TransactionType.Expense : TransactionType.Income,
                CategoryId = category.Id,
                Category = category,
                IsDeleted = false
            });
        }

        await transactionRepository.SaveChangesAsync();

        return new ImportResultDto
        {
            Total = parsedTransactionCount + parseResult.Errors.Count,
            Imported = parsedTransactionCount,
            Errors = parseResult.Errors.Select(e => new ImportErrorDto
            {
                Row = e.Row,
                Reason = e.Reason
            }).ToList()
        };
    }
}
