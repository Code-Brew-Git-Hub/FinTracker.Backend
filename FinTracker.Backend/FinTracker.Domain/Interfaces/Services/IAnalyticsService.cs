using FinTracker.Domain.Dtos.Analytics;
using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Interfaces.Services;

public interface IAnalyticsService
{
    Task<AnalyticsSummaryDto> GetSummaryAsync(AnalyticsFilterDto filter);
    Task<IEnumerable<CategoryStatDto>> GetByCategoryAsync(AnalyticsFilterDto filter);
    Task<IEnumerable<TagStatDto>> GetByTagAsync(AnalyticsFilterDto filter);
    Task<IEnumerable<TimeStatDto>> GetByTimeAsync(AnalyticsFilterDto filter, TimeGrouping grouping);
}
