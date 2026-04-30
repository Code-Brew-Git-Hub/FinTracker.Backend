using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<Transaction[]>> GetAll()
    { 
        return transactionService.
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<Transaction>> GetById(int id, bool hideDeleted = true)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Create(string data, decimal amount, string currency, string category,
        string? description, string? scope, string? comment)
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<ActionResult> Update()
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    [Route("bulk")]
    [HttpPatch]
    public async Task<ActionResult> BulkUpdate()
    {
        throw new NotImplementedException();
    }
}
