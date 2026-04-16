using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Parser;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Transactions;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Upload")]
public class UploadController(ITransactionService transactionService) : ControllerBase
{
    [HttpPost]
    [Route("Manual")]
    public async Task<IActionResult> CreateManualAsync(string dataStr, decimal amount, string currencyStr, string description,
        string category, string typeStr, string comment)
    {
        if (!DateTime.TryParse(dataStr, out var data))
            return BadRequest("Неправильно введна дата операции");
        if (!Enum.TryParse<CurrencyType>(currencyStr, out var currency))
            return BadRequest("Неправильно введна валюта операции");
        if (!Enum.TryParse<TransactionType>(typeStr, out var type))
            return BadRequest("Неправильно введен тип операции");
        data = data.ToUniversalTime();        

        await transactionService.CreateAsync(data, amount, currency, description, 
            category, type, SourceType.Manual, comment, false);
        return NoContent();
    }

    [HttpPost]
    [Route("Csv")]
    public async Task<IActionResult> CreateCsvAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не передан или пуст.");

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (extension is not ".csv")
            return BadRequest("Допустимый формат файла: .csv");

        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);

        var parser = new CsvParser();
        var transactions = await parser.ParseCSV(reader);

        foreach (var transaction in transactions)
        {
            transaction.Source = SourceType.CSV;
            transaction.Comment = string.Empty;
            transaction.Type = (transaction.Category == "Переводы") ? TransactionType.Transfer 
                : (transaction.Amount < 0 ? TransactionType.Expense : TransactionType.Income);
            transaction.IsDeleted = false;
            transaction.Date = transaction.Date.ToUniversalTime();

            await transactionService.AddAsync(transaction);
        }

        // Возвращаем сводку 
        return Ok(new
        {
            Created = transactions.Count
        });
    }

}
