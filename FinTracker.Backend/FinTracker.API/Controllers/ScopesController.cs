using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Models;
using FinTracker.Domain.FilterModels;
using FinTracker.Domain.Enums;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("/api/scopes")]
public class ScopesController(ITransactionService transactionService, IScopeService scopeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Scope[]>> GetAll()
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<Scope>> GetById(int id)
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
    {  throw new NotImplementedException();}    
}
