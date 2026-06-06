using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.Models.ModelsToHelp;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/validation/issues")]
public class ValidationIssuesController(IValidationIssueService validationIssueService,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<ValidationIssueDto[]>>> GetAll(
        [FromQuery] Guid? ruleId,
        [FromQuery] ValidationIssueStatus? status)
    {
        var issues = await validationIssueService.GetFilteredAsync(new ValidationIssueFilter
        {
            RuleId = ruleId,
            Status = status
        });

        return Ok(ApiResponse.Ok(mapper.Map<ValidationIssueDto[]>(issues)));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ValidationIssueDto>>> GetById([FromRoute] Guid id)
    {
        var issue = await validationIssueService.GetByIdAsync(id);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationIssueDto>(issue)));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<ValidationIssueDto>>> Create([FromBody] CreateValidationIssueDto dto)
    {
        var issue = await validationIssueService.CreateAsync(dto);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationIssueDto>(issue)));
    }

    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ValidationIssueDto>>> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateValidationIssueDto dto)
    {
        var issue = await validationIssueService.UpdateAsync(id, dto);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationIssueDto>(issue)));
    }

    [HttpPost("{id:guid}/confirm")]
    public async Task<ActionResult<ApiResponse<ValidationIssueDto>>> Confirm(
        [FromRoute] Guid id,
        [FromBody] ConfirmValidationIssueDto dto)
    {
        var issue = await validationIssueService.ConfirmAsync(id, dto);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationIssueDto>(issue)));
    }

    [HttpPost("{id:guid}/reject")]
    public async Task<ActionResult<ApiResponse<ValidationIssueDto>>> Reject(
        [FromRoute] Guid id,
        [FromBody] RejectValidationIssueDto dto)
    {
        var issue = await validationIssueService.RejectAsync(id, dto);
        return Ok(ApiResponse.Ok(mapper.Map<ValidationIssueDto>(issue)));
    }
}
