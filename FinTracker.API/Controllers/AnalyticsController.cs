using FinTracker.Domain.Dtos.Analytics;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(IAnalyticsService analyticsService) : ControllerBase
{
    [HttpGet("summary")]
    public async Task<ActionResult<ApiResponse<AnalyticsSummaryDto>>> GetSummary([FromQuery] AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    [HttpGet("by-category")]
        public async Task<ActionResult<ApiResponse<CategoryStatDto[]>>> GetByCategory([FromQuery] AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    [HttpGet("by-tag")]
        public async Task<ActionResult<ApiResponse<TagStatDto[]>>> GetByTag([FromQuery] AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    [HttpGet("by-time")]
        public async Task<ActionResult<ApiResponse<TimeStatDto[]>>> GetByTime([FromQuery] AnalyticsFilterDto filter, [FromQuery] TimeGrouping grouping)
    {
        throw new NotImplementedException();
    }
}
