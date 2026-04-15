
using FinTracker.Data.Repositories;
using FinTracker.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinTracker.Data;

public static class Extensions
{
    public static IServiceCollection AddData(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        serviceCollection.AddDbContext<AppContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Database=FinTrackerDb;Username=postgres;Password=123456");
        });
        return serviceCollection;
    }

    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITransactionService, TransactionService>();
        return serviceCollection;
    }
}
