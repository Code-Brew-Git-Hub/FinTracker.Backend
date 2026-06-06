using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Dtos.Validation;
using FinTracker.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/validation")]
public class ValidationController(IValidationService validationService) : ControllerBase
{
    [HttpPost("run")]
    public async Task<ActionResult<ApiResponse<RunValidationResultDto>>> Run(
        [FromBody] RunValidationDto? dto = null)
    {
        var result = await validationService.RunIdenticalTransactionsAsync(dto?.RuleId);
        return Ok(ApiResponse.Ok(result));
    }
}
