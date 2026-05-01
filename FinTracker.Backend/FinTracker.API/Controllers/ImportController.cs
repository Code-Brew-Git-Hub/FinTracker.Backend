using FinTracker.Data.Services;
using FinTracker.Domain.Dtos.Transactions;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Enums;
using FinTracker.Parser;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/import")]
public class ImportController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{
    [HttpPost("csv")]
    public async Task<ActionResult<ApiResponse<TransactionDto>>> UploadCsv(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest(ApiResponse<TransactionDto>.Fail("The file has not been transferred or is empty"));

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (extension is not ".csv")
            return BadRequest(ApiResponse<TransactionDto>.Fail("Incorrect file: The acceptable file format is .csv"));
        
        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);

        var parser = new CsvParser();
        var transactions = await parser.ParseCSV(reader);

        throw new NotImplementedException();

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
