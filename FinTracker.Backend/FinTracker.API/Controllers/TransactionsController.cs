using FinTracker.Data.Services;
using FinTracker.Domain.Enums;
using FinTracker.Domain.FilterModels;
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
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<Transaction>> GetById(int id, bool hideDeleted = true)
    {
        throw new NotImplementedException();
        if (id < 0)
            return BadRequest("id должен быть больше нуля (id > 0)");

        var transaction = await transactionService.GetByIdAsync(id, hideDeleted);

        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует, или она удалена");

        return transaction;
    }

    [HttpPost]
    public async Task<ActionResult> Create(string data, decimal amount, string currency, string category,
        string? description, string? scope, string? comment)
    {
        throw new NotImplementedException();

        if (!DateTime.TryParse(data, out var dataEnum))
            return BadRequest("Неправильно введна дата операции");

        if (!Enum.TryParse<CategoryEnum>(category, out var categoryEnum))
            return BadRequest("Неправильно введна категория");


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

        var desc = description != null ? description : string.Empty;
        var comm = comment != null ? comment : string.Empty;

        await transactionService.CreateAsync(dataEnum.ToUniversalTime(), amount, currency, categoryEnum,
            desc, scopeStruct, comm, false/*, fromStruct, toStruct*/);
        return NoContent();
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

        if (id < 0)
            return BadRequest("id должен быть больше нуля (id >= 0)");

        var transaction = await transactionService.GetByIdAsync(id, false);
        if (transaction == null)
            return NotFound($"Транзакции с id {id} не существует");

        transaction.IsDeleted = true;

        await transactionService.UpdateAsync(transaction);
        return NoContent();
    }

    [Route("bulk")]
    [HttpPatch]
    public async Task<ActionResult> BulkUpdate()
    {
        throw new NotImplementedException();
    }



    
    [Route("GetPack/{from}-{to}")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetPack(int from, int to, bool hideDeleted)
    {
        if (from < 0)
            return BadRequest("from должен быть больше нуля (from >= 0)");
        if (to < 0)
            return BadRequest("to должен быть больше нуля (to >= 0)");

        var transactions = new List<Transaction>();

        for (int id = from; id <= to; id++)
        {
            var transaction = await transactionService.GetByIdAsync(id, hideDeleted);
            if (transaction == null)
                continue;
            transactions.Add(transaction);
        }

        return Ok(new
        {
            RequestedQuantity = to - from + 1,  // Запрошенное количество транзакций
            ReceivedQuantity = transactions.Count,  // Полученное количество транзакций
            Transactions = transactions  // Транзакции
        });
    }

    [Route("GetByFilters")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetByFilters([FromQuery] TransactionFiltersString filters, bool hideDeleted)
    {
        var DateFilter = filters.DateFilter;
        var AmountFilter = filters.AmountFilter;
        var categoryFilter = filters.CategoryFilter;
        var typeFilter = filters.TypeFilter;
        var scopeFilter = filters.ScopeFilter;

        List<CategoryEnum>? CategoryFilter = null;

        if (categoryFilter != null && categoryFilter.Any())
        {
            CategoryFilter = new();
            foreach (var category in categoryFilter)
            {
                if (!Enum.TryParse<CategoryEnum>(category, out var categoryEnum))
                    return BadRequest("");
                CategoryFilter.Add(categoryEnum);
            }
        }

        List<TypeEnum>? TypeFilter = null;

        if (typeFilter != null && typeFilter.Any())
        {
            TypeFilter = new();
            foreach (var type in typeFilter)
            {
                if (!Enum.TryParse<TypeEnum>(type, out var typeEnum))
                    return BadRequest();
                TypeFilter.Add(typeEnum);
            }
        }

        List<Scope>? ScopeFilter = null;

        if (scopeFilter != null && scopeFilter.Any())
        {
            ScopeFilter = new();
            foreach (var scope in scopeFilter)
            {
                var scopeStruct = await scopeService.GetScopeByName(scope);
                if (scopeStruct == null)
                    return BadRequest();
                ScopeFilter.Add(scopeStruct);
            }
        }

        var Filters = new TransactionFilters()
        {
            DateFilter = DateFilter,
            AmountFilter = AmountFilter,
            CategoryFilter = CategoryFilter,
            TypeFilter = TypeFilter,
            ScopeFilter = ScopeFilter,
        };

        var transactions = await transactionService.GetByFiltersAsync(Filters, hideDeleted);

        if (transactions == null || transactions.Count == 0)
            return NotFound("Транзакций с указанными фильтрами не найдено");

        return Ok(transactions);
    }
}
