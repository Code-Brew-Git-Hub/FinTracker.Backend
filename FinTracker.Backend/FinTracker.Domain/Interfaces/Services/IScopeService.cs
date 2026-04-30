namespace FinTracker.Data.Services;

public interface IScopeService
{
    Task CreateAsync(string name, CancellationToken cancellationToken = default);
}
