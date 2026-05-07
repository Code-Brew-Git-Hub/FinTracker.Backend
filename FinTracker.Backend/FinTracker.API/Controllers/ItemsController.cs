using FinTracker.Domain.Dtos.TransactionItems;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/transactions/{transactionId:guid}/items")]
public class ItemsController(IItemService itemService, 
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TransactionItemDto>>>> GetAll([FromRoute] Guid transactionId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<TransactionItemDto>>> Create([FromRoute] Guid transactionId, [FromBody] CreateTransactionItemDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{itemId:guid}")]
    public async Task<ActionResult<ApiResponse<TransactionItemDto>>> Update([FromRoute] Guid transactionId, [FromRoute] Guid itemId, [FromBody] UpdateTransactionItemDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{itemId:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid transactionId, [FromRoute] Guid itemId)
    {
        throw new NotImplementedException();
    }
}