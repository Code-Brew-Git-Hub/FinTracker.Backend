using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;
using FinTracker.Domain.Enums;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Aggrigation")]
public class AggrigationController(ITransactionService transactionService) : ControllerBase
{
    [Route("GetByFilters")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetByFilters([FromQuery] TransactionFilters filters)
    {
        var transactions = await transactionService.GetByFiltersAsync(filters);

        if (transactions == null || transactions.Count == 0)
            return NotFound("Транзакций с указанными фильтрами не найдено");

        return Ok(transactions);
    }
}
