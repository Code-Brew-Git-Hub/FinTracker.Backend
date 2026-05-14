using FinTracker.Domain.Dtos.Import;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;
using FinTracker.Parser;

namespace FinTracker.Data.Services;

public class ImportService(TransactionParser parser,
    ITransactionRepository transactionRepository,
    ICategoryRepository categoryRepository) : IImportService
{
    public async Task<ImportResultDto> ImportAsync(StreamReader reader, string filename)
    {
        var parseResult = await parser.Parse(reader, filename);

        if (!parseResult.Transactions.Any() && parseResult.Errors.Any())
            throw new ArgumentException(parseResult.Errors.First().Reason);

        var categoryCache = new Dictionary<string, Category>();

        foreach (var p in parseResult.Transactions)
        {
            var categoryName = p.CategoryName;

            if (!categoryCache.TryGetValue(categoryName, out var category))
            {
                category = await categoryRepository.GetByNameAsync(categoryName);

                if (category == null)
                {
                    category = new Category { Id = Guid.NewGuid(), Name = categoryName };
                    await categoryRepository.AddAsync(category);
                    await categoryRepository.SaveChangesAsync();
                }

                categoryCache[categoryName] = category;
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
            Total = parseResult.Transactions.Count + parseResult.Errors.Count,
            Imported = parseResult.Transactions.Count,
            Errors = parseResult.Errors.Select(e => new ImportErrorDto
            {
                Row = e.Row,
                Reason = e.Reason
            }).ToList()
        };
    }
}
