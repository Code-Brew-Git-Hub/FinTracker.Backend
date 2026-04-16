using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Transactions")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    [Route("GetById")]
    [HttpGet]
    public async Task<Transaction> GetById(int id)
    {
        if (id < 0)
            throw new Exception("id must be grater then zero (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id);

        if (transaction == null)
            throw new Exception("Транзакции с таким id не существует");

        return transaction;
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<List<Transaction>> GetAll()
    {
        return await transactionService.GetAllAsync();
    }
}


