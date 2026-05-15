using FinTracker.Domain.Dtos.Analytics;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Services;

namespace FinTracker.Data.Services;

public class AnalyticsService : IAnalyticsService
{
    public Task<List<CategoryStatDto>> GetByCategoryAsync(AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public Task<List<TagStatDto>> GetByTagAsync(AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public Task<List<TimeStatDto>> GetByTimeAsync(AnalyticsFilterDto filter, TimeGrouping grouping)
    {
        throw new NotImplementedException();
    }

    public Task<AnalyticsSummaryDto> GetSummaryAsync(AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }
}
