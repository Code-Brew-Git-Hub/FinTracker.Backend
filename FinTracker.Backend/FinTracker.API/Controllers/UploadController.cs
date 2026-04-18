using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Parser;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Upload")]
public class UploadController(ITransactionService transactionService) : ControllerBase
{
    [HttpPost]
    [Route("Manual")]
    public async Task<ActionResult> CreateManualAsync(string data, decimal amount, string currency, string description,
        string category, string type, string comment)
    {
        if (!DateTime.TryParse(data, out var dataEnum))
            return BadRequest("Неправильно введна дата операции");
        if (!Enum.TryParse<TransactionType>(type, out var typeEnum))
            return BadRequest("Неправильно введен тип операции");
        dataEnum = dataEnum.ToUniversalTime();        

        await transactionService.CreateAsync(dataEnum, amount, currency, description, 
            category, typeEnum, SourceType.Manual, comment, false);
        return NoContent();
    }

    [HttpPost]
    [Route("Csv")]
    public async Task<ActionResult> CreateCsvAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не передан или пуст.");

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (extension is not ".csv")
            return BadRequest("Допустимый формат файла: .csv");

        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);

        var parser = new TransactionParser();
        var transactions = await parser.Parse(reader, file.FileName);

        foreach (var transaction in transactions)
        {
            transaction.Source = SourceType.CSV;
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
