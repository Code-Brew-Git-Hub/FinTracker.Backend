using FinTracker.Domain.Dtos.Analytics;
using FinTracker.Domain.Enums;
using FinTracker.Domain.Interfaces.Services;

namespace FinTracker.Data.Services;

public class AnalyticsService : IAnalyticsService
{
    public Task<IEnumerable<CategoryStatDto>> GetByCategoryAsync(AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TagStatDto>> GetByTagAsync(AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TimeStatDto>> GetByTimeAsync(AnalyticsFilterDto filter, TimeGrouping grouping)
    {
        throw new NotImplementedException();
    }

    public Task<AnalyticsSummaryDto> GetSummaryAsync(AnalyticsFilterDto filter)
    {
        throw new NotImplementedException();
    }
}
