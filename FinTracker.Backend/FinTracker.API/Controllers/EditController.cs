using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Edit")]
public class EditController(ITransactionService transactionService) : ControllerBase
{
    [Route("SoftDelete/{id}")]
    [HttpDelete]    
    public async Task<ActionResult> SoftDelete(int id)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id, false);
        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует");

        transaction.IsDeleted = true;

        await transactionService.UpdateAsync(transaction);
        return NoContent();
    }

    [Route("Update/{id}")]
    [HttpPut]
    public async Task<ActionResult> Update(int id, DateTime? date, decimal? amount, string? currency,
        string? description, string? category, string? comment)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id > 0)");
        if (date == null && amount == null && currency == null && description == null && category == null && comment == null)
            return BadRequest("Вы не переадли данные, которые надо обновить");

        var transaction = await transactionService.GetByIdAsync(id, false);

        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует");

        if (date != null)
            transaction.Date = (DateTime)date;

        if (amount != null)
        {
            transaction.Amount = (decimal)amount;
            transaction.Type = (transaction.Category == "Переводы") ? TransactionType.Transfer
                : (transaction.Amount < 0 ? TransactionType.Expense : TransactionType.Income);
        }

        if (currency != null)
            transaction.Currency = currency;

        if (description != null)
            transaction.Description = description;

        if (category != null)
        {
            transaction.Category = category;
            transaction.Type = (transaction.Category == "Переводы") ? TransactionType.Transfer
                : (transaction.Amount < 0 ? TransactionType.Expense : TransactionType.Income);
        }

        if (comment != null)
            transaction.Comment = comment;

        await transactionService.UpdateAsync(transaction);

        return Ok();
    }
}
