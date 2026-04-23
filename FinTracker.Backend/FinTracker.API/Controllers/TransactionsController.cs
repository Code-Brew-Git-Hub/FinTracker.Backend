using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Transactions")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    #region Получение транзакции по id
    [Route("GetById/{id}")]
    [HttpGet]
    public async Task<ActionResult<Transaction>> GetById(int id, bool hideDeleted)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id, hideDeleted);

        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует, или она удалена");

        return transaction;
    }
    #endregion

    #region Получение всех транзакций
    [Route("GetAll")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetAll(bool accept, bool hideDeleted)
    {
        if (!accept)
            return NoContent();
        return await transactionService.GetAllAsync(hideDeleted);
    }
    #endregion

    #region Получение пачки транзакций
    [Route("GetPack/{from}-{to}")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetPack(int from, int to, bool hideDeleted)
    {
        if (from < 0)
            return BadRequest("from должен быть больше нуля (from >= 0)");
        if (to < 0)
            return BadRequest("to должен быть больше нуля (to >= 0)");

        var transactions = new List<Transaction>();

        for (int id = from; id <= to; id++)
        {
            var transaction = await transactionService.GetByIdAsync(id, hideDeleted);
            if (transaction == null)
                continue;
            transactions.Add(transaction);
        }

        return Ok(new
        {
            RequestedQuantity = to - from + 1,  // Запрошенное количество транзакций
            ReceivedQuantity = transactions.Count,  // Полученное количество транзакций
            Transactions = transactions  // Транзакции
        });
    }
#endregion
}
