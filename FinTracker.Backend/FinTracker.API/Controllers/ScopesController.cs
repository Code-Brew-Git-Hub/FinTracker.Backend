using Microsoft.AspNetCore.Mvc;
using FinTracker.Data.Services;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Dtos.Scopes;
using MapsterMapper;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("/api/scopes")]
public class ScopesController(IScopeService scopeService,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ScopeDto>>>> GetAll()
    {
        var scopes = await scopeService.GetAllAsync();

        var scopesDto = mapper.Map<IEnumerable<ScopeDto>>(scopes);

        return Ok(ApiResponse<IEnumerable<ScopeDto>>.Ok(scopesDto));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ScopeDto>>> GetById([FromRoute] Guid id)
    {
        var scope = await scopeService.GetByIdAsync(id);

        var scopeDto = mapper.Map<ScopeDto>(scope);

        return Ok(ApiResponse<ScopeDto>.Ok(scopeDto));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<ScopeDto>>> Create([FromBody] CreateScopeDto dto)
    {
        var createdScope = await scopeService.CreateAsync(dto.Name);

        var createdScopeDto = mapper.Map<ScopeDto>(createdScope);

        return Ok(ApiResponse<ScopeDto>.Ok(createdScopeDto));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ScopeDto>>> Update([FromRoute] Guid id, [FromBody] UpdateScopeDto dto)
    {
        var updatedScope = await scopeService.UpdateAsync(id, dto.Name);

        var updatedScopeDto = mapper.Map<ScopeDto>(updatedScope);

        return Ok(ApiResponse<ScopeDto>.Ok(updatedScopeDto));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await scopeService.DeleteAsync(id);

        return NoContent();
    }    
}
