using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Editing")]
public class EditingController(ITransactionService transactionService) : ControllerBase
{
    #region "Мягкое" удаление
    [Route("SoftDelete/{id}")]
    [HttpDelete]    
    public async Task<ActionResult> SoftDelete(int id)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id >= 0)");

        var transaction = await transactionService.GetByIdAsync(id, false);
        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует");

        transaction.IsDeleted = true;

        await transactionService.UpdateAsync(transaction);
        return NoContent();
    }
    #endregion

    #region Обновление значений транзакции (изменение транзакции)
    [Route("Update/{id}")]
    [HttpPut]
    public async Task<ActionResult> Update(int id/*, DateTime? date, decimal? amount, string? currency,
        string? description, string? category, string? comment*/)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id > 0)");
        //if (date == null && amount == null && currency == null && description == null && category == null && comment == null)
        //    return BadRequest("Вы не переадли данные, которые надо обновить");

        throw new NotImplementedException("Надо реализовать редактирование транзакции");

        return Ok();
    }
    #endregion
}
