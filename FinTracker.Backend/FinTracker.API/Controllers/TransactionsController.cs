using FinTracker.Data.Services;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;
using FinTracker.Domain.ModelsToPrint;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController(ITransactionService transactionService, IScopeService scopeService,
    ICategoryService categoryService) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<Transaction[]>> GetAll()
    { 
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<Transaction>> GetById(Guid id, bool includeDeleted = false)
    {
        var transaction = await transactionService.GetByIdAsync(id);

        if (transaction == null)
            return NotFound($"Транзакция с id {id} не существует");

        var transactionToPrint = new TransactionToPrint(transaction);

        if (includeDeleted || transaction.IsDeleted == false)
            return Ok(transactionToPrint);

        return NotFound($"Транзакция с id {id} является удаленной");
    }

    [HttpPost]
    public async Task<ActionResult> Create(decimal amount, string currency, DateTime date, 
        string? description, string? comment, string category, string? scope)
    {
        var Category = await categoryService.GetByNameAsync(category);

        if (Category == null)
            return BadRequest($"Категория {category} не найдена");

        var Scope = scope != null ? await scopeService.GetByNameAsync(scope) : null;

        await transactionService.CreateAsync(amount, currency, date, description, comment, Category, Scope);

        return Ok(new
        {
            Created = 1
        });
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<ActionResult> Update(Guid id, decimal? amount, string? currency, DateTime? date,
        string? description, string? comment, string? category, string? scope, bool? isDeleted)
    {
        var transaction = await transactionService.GetByIdAsync(id);
        if (transaction == null)
            return NotFound($"Транзакция с id {id} не существует");

        if (amount != null)
            transaction.Amount = (decimal)amount;
        if (currency != null) 
            transaction.Currency = currency;
        if (date != null)
            transaction.Date = (DateTime)date;
        if (description != null)
            transaction.Description = description;
        if (comment != null)
            transaction.Comment = comment;
        if (isDeleted != null)
            transaction.IsDeleted = (bool)isDeleted;
        if (category != null)
        {
            var Category = await categoryService.GetByNameAsync(category);
            if (Category == null)
                return NotFound($"Категоря {category} не найдена");
            transaction.Category = Category;
            transaction.CategoryId = Category.Id;
        }
        if (scope != null)
        {
            var Scope = await scopeService.GetByNameAsync(scope);
            if (Scope == null)
                return NotFound($"Группа {scope} не найдена");
            transaction.Scope = Scope;
            transaction.ScopeId = Scope.Id;
        }

        await transactionService.UpdateAsync(transaction);

        return Ok(new TransactionToPrint(transaction));
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> SoftDelete(Guid id)
    {
        var transaction = await transactionService.GetByIdAsync(id);
        if (transaction == null)
            return NotFound($"Транзакция с id {id} не существует");

        transaction.IsDeleted = true;

        await transactionService.UpdateAsync(transaction);

        return Ok(new TransactionToPrint(transaction));
    }

    [Route("bulk")]
    [HttpPatch]
    public async Task<ActionResult> BulkUpdate()
    {
        throw new NotImplementedException();
    }
}
