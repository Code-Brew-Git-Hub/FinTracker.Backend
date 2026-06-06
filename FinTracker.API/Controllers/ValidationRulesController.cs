using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/validation/rules")]
public class ValidationRulesController(IValidationRuleService validationRuleService,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<ValidationRuleDto[]>>> GetAll()
    {
        var rules = await validationRuleService.GetAllAsync();
        return Ok(ApiResponse.Ok(mapper.Map<ValidationRuleDto[]>(rules)));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ValidationRuleDto>>> GetById([FromRoute] Guid id)
    {
        var rule = await validationRuleService.GetByIdAsync(id);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationRuleDto>(rule)));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<ValidationRuleDto>>> Create([FromBody] CreateValidationRuleDto dto)
    {
        var rule = await validationRuleService.CreateAsync(dto);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationRuleDto>(rule)));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ValidationRuleDto>>> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateValidationRuleDto dto)
    {
        var rule = await validationRuleService.UpdateAsync(id, dto);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationRuleDto>(rule)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await validationRuleService.DeleteAsync(id);
        return NoContent();
    }
}
