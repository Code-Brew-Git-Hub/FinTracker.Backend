using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;
using FinTracker.Domain.FilterModels;
using FinTracker.Domain.Enums;
using Microsoft.AspNetCore.Components.Forms;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("Aggrigation")]
public class AggrigationController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{
    [Route("GetByFilters")]
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> GetByFilters([FromQuery]TransactionFiltersString filters, bool hideDeleted)
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
