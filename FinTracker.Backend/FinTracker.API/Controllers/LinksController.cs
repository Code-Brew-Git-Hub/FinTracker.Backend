using FinTracker.Domain.Dtos.TransactionLinks;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/links")]
public class LinksController(ILinkService linkService, IMapper mapper) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<TransactionLinkDto>>> GetById([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<TransactionLinkDto>>> Create([FromBody] CreateTransactionLinkDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{id:guid}/transactions")]
    public async Task<ActionResult<ApiResponse<TransactionLinkDto>>> AddTransaction([FromRoute] Guid id, [FromBody] AddTransactionToLinkDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}/transactions/{transactionId:guid}")]
    public async Task<ActionResult> RemoveTransaction([FromRoute] Guid id, [FromRoute] Guid transactionId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }
}
