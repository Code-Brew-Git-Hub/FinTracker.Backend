using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Parser;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Upload")]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{
    [HttpPost]
    [Route("Manual")]
    public async Task<IActionResult> CreateManualAsync(string dataStr, decimal amount, string currencyStr, string description,
        string category, string typeStr, string comment)
    {
        if (!DateTime.TryParse(dataStr, out var data))
            throw new Exception("Неправильно введна дата операции");
        if (!Enum.TryParse<CurrencyType>(currencyStr, out var currency))
            throw new Exception("Неправильно введна валюта операции");
        if (!Enum.TryParse<TransactionType>(typeStr, out var type))
            throw new Exception("Неправильно введен тип операции");
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

        // Читаем файл построчно
        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);

        var parser = new CsvParser();
        var transactions = parser.ParseCSV(reader);

        // Добавляем в бд
        foreach (var transaction in transactions)
        {
            
            var type = (transaction.Category == "Переводы") ? TransactionType.Transfer 
                : (transaction.Amount < 0 ? TransactionType.Expense : TransactionType.Income);

            await transactionService.CreateAsync(
                transaction.Date.ToUniversalTime(),
                transaction.Amount,
                transaction.Currency,
                transaction.Description,
                transaction.Category,
                type,
                SourceType.CSV,
                string.Empty,
                false
            );
        }

        // Возвращаем сводку 
        return Ok(new
        {
            Created = transactions.Count
        });
    }

}
