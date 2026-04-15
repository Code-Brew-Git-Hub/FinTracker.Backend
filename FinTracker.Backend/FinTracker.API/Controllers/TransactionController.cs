using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Upload/Manual")]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(string dataStr, decimal amount, string currencyStr, string description,
        string category, string typeStr, string comment)
    {
        if (!DateTime.TryParse(dataStr, out var data))
            throw new Exception("Неправильно введна дата операции");
        if (!Enum.TryParse<CurrencyType>(currencyStr, out var currency))
            throw new Exception("Неправильно введна валюта операции");
        if (!Enum.TryParse<TransactionType>(typeStr, out var type))
            throw new Exception("Неправильно введен тип операции");
        data = data.ToUniversalTime();
        //DateTime.SpecifyKind(data)

        await transactionService.CreateAsync(data, amount, currency, description, 
            category, type, SourceType.Manual, comment, false);
        return NoContent();
    }
}
