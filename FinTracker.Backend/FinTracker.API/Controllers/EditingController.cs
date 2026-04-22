using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Editing")]
public class EditingController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
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
    public async Task<ActionResult> Update(int id, string? date, decimal? amount, string? currency,
        string? category, string? description, string? scope, string? comment)
    {
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id >= 0)");

        if (date == null && amount == null && currency == null && category == null 
            && description == null && scope == null && comment == null)
            return BadRequest("Вы не переадли данные, которые надо обновить");

        if (!DateTime.TryParse(date, out var DateEnum))
            return BadRequest("Неправильное значение date");

        if (!Enum.TryParse<CategoryEnum>(category, out var categoryEnum))
            return BadRequest("Неправильное значение category");

        Scope? scopeStruct = null;

        if (scope != null)
        {
            scopeStruct = await scopeService.GetScopeByName(scope);
            if (scopeStruct == null)
            {
                await scopeService.CreateAsync(scope);
                scopeStruct = await scopeService.GetScopeByName(scope);
            }
        }

        throw new NotImplementedException("Надо реализовать редактирование транзакции");

        return Ok();
    }
    #endregion
}
