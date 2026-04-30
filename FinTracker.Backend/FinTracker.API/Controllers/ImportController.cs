using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Parser;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/import")]
public class ImportController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{

    [Route("csv")]
    [HttpPost]
    public async Task<ActionResult> UploadCsv(IFormFile file)
    {
        throw new NotImplementedException();

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
            transaction.Type = transaction.Amount < 0 ? TransactionType.Expense : TransactionType.Income;
            transaction.IsDeleted = false;

            //await transactionService.AddAsync(transaction);
        }

        // Возвращаем сводку 
        return Ok(new
        {
            Created = transactions.Count
        });
    }

    [Route("csv/preview")]
    [HttpPost]
    public async Task<ActionResult<List<string>>> GetColumnMapping(IFormFile file)
    {
        throw new NotImplementedException();
    }
}
