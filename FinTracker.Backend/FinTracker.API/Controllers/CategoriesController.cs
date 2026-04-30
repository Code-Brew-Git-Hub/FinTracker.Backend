using FinTracker.Data.Services;
using FinTracker.Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{
    [HttpGet]
    public async Task<Category[]> GetAll()
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<Category> GetById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Create()
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<ActionResult> Update(int id)
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
