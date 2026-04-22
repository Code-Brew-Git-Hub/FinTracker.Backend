using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;
using FinTracker.Parser;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Upload")]
public class UploadController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{
    [HttpPost]
    [Route("Manual")]
    public async Task<ActionResult> CreateManualAsync(string data, decimal amount, string currency, string category, 
        string description, string type, string? scope, string comment/*, string? from, string? to*/)
    {
        if (!DateTime.TryParse(data, out var dataEnum))
            return BadRequest("Неправильно введна дата операции");

        if (!Enum.TryParse<CategoryEnum>(category, out var categoryEnum))
            return BadRequest("Неправильно введна категория");

        if (!Enum.TryParse<TypeEnum>(type, out var typeEnum))
            return BadRequest("Неправильно введен тип операции");
        dataEnum = dataEnum.ToUniversalTime();

        Scope? scopeStruct = null;
        if (scope != null)
        {
            scopeStruct = await scopeService.GetScopeByName(scope);
            await scopeService.CreateAsync(scope);
            scopeStruct = await scopeService.GetScopeByName(scope);
        }

        await transactionService.CreateAsync(dataEnum, amount, currency, categoryEnum,
            description, typeEnum, scopeStruct, comment, false/*, fromStruct, toStruct*/);
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
            transaction.Date = transaction.Date.ToUniversalTime();
            transaction.Type = transaction.Amount < 0 ? TypeEnum.Expense : TypeEnum.Income;
            transaction.IsDeleted = false;            

            await transactionService.AddAsync(transaction);
        }

        // Возвращаем сводку 
        return Ok(new
        {
            Created = transactions.Count
        });
    }

}
