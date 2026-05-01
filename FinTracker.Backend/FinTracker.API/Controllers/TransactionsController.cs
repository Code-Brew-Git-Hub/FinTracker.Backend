using FinTracker.Data.Services;
using FinTracker.Domain.Dtos.Transactions;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController(ITransactionService transactionService, IScopeService scopeService,
    ICategoryService categoryService) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<TransactionDto[]>> GetAll()
    { 
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<TransactionDto>> GetById(Guid id, bool includeDeleted = false)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<TransactionDto>> Create(decimal amount, string currency, DateTime date, 
        string? description, string? comment, string category, string? scope)
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<ActionResult> Update(Guid id, decimal? amount, string? currency, DateTime? date,
        string? description, string? comment, string? category, string? scope, bool? isDeleted)
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> SoftDelete(Guid id)
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
