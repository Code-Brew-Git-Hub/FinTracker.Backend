using FinTracker.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Edit")]
public class EditController(ITransactionService transactionService) : ControllerBase
{
    [Route("SoftDelete/{id}")]
    [HttpDelete]    
    public async Task<IActionResult> SoftDelete(int id)
    {
        if (id < 0)
            return BadRequest("id must be grater then zero (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id);
        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует");

        transaction.IsDeleted = true;

        await transactionService.UpdateAsync(transaction);
        return NoContent();
    }
}
