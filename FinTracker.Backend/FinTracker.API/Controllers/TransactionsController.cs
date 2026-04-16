using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;


namespace FinTracker.API.Controllers;

[ApiController]
[Route("Transactions")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
    {
    [Route("ById")]
    [HttpGet]
    public async Task<Transaction> GetById(int id)
    {
        if (id < 0)
            throw new Exception("id must be grater then zero or zero (id>0)");
        return await transactionService.GetById(id);
    }

    [HttpGet]
    public async Task<List<Transaction>> GetAll()
    {
        return await transactionService.GetAll();
    }
}


