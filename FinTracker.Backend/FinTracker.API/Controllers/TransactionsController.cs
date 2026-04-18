using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Transactions")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    [Route("GetById/{id}")]
    [HttpGet]
    public async Task<ActionResult<Transaction>> GetById(int id)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id);

        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует");

        return transaction;
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetAll(bool accept)
    {
        if (!accept)
            return NoContent();
        return await transactionService.GetAllAsync();
    }

    [Route("GetPack/{from}-{to}")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetPack(int from, int to)
    {
        if (from < 0)
            return BadRequest("from должен быть больше нуля (from > 0)");
        if (to < 0)
            return BadRequest("to должен быть больше нуля (to > 0)");

        var transactions = new List<Transaction>();

        for (int i = from; i <= to; i++)
        {
            var transaction = await transactionService.GetByIdAsync(i);
            if (transaction == null)
                continue;
            transactions.Add(transaction);
        }
        
        return transactions;
    }
}


