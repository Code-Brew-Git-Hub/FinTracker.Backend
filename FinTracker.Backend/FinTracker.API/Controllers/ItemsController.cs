using FinTracker.Domain.Dtos.TransactionItems;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models;
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
        var items = await itemService.GetAllAsync(transactionId);

        var itemsDto = mapper.Map<IEnumerable<TransactionItemDto>>(items);

        return Ok(ApiResponse.Ok(itemsDto));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<TransactionItemDto>>> Create([FromRoute] Guid transactionId, [FromBody] CreateTransactionItemDto dto)
    {
        var createdItem = await itemService.CreateAsync(transactionId, dto);

        var createdItemDto = mapper.Map<TransactionItemDto>(createdItem);

        return Ok(ApiResponse.Ok(createdItemDto));
    }

    [HttpPut("{itemId:guid}")]
    public async Task<ActionResult<ApiResponse<TransactionItemDto>>> Update([FromRoute] Guid transactionId, [FromRoute] Guid itemId, [FromBody] UpdateTransactionItemDto dto)
    {
        var updatedItem = await itemService.UpdateAsync(transactionId, itemId, dto);

        var updatedItemDto = mapper.Map<TransactionItemDto>(updatedItem);

        return Ok(ApiResponse.Ok(updatedItemDto));
    }

    [HttpDelete("{itemId:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid transactionId, [FromRoute] Guid itemId)
    {
        await itemService.DeleteAsync(transactionId, itemId);

        return NoContent();
    }
}