using FinTracker.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Checking")]
public class CheckingController(ITransactionService transactionService) : ControllerBase
{
    [Route("SoftDelete")]
    [HttpDelete]    
    public async Task<IActionResult> SoftDelete(int id)
    {
        if (id < 0)
            throw new Exception("id must be grater then zero (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id);
        if (transaction == null)
            throw new Exception("Такой транзакции не существует");

        transaction.IsDeleted = true;

        await transactionService.UpdateAsync(transaction);
        return NoContent();
    }
}
