using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Data.Repositories;
using FinTracker.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinTracker.Data;

public static class Extensions
{
    public static IServiceCollection AddContext(this IServiceCollection serviceCollection)
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "FinTrackerDb";
        var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "123456";

        serviceCollection.AddDbContext<AppDbContext>(x =>
        {
            x.UseNpgsql($"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}");
        });

        return serviceCollection;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        serviceCollection.AddScoped<IScopeRepository, ScopeRepository>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<ITagRepository, TagRepository>();

        return serviceCollection;
    }

    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITransactionService, TransactionService>();
        serviceCollection.AddScoped<IScopeService, ScopeService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<ITagService, TagService>();

        return serviceCollection;
    }
}
