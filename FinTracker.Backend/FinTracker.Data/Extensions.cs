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
        var DbHost = Environment.GetEnvironmentVariable("DBHOST") ?? "localhost";
        var Database = Environment.GetEnvironmentVariable("DATABASE") ?? "FinTrackerDb";
        var Username = Environment.GetEnvironmentVariable("DBUSERNAME") ?? "postgres";
        var Password = Environment.GetEnvironmentVariable("PASSWORD") ?? "123456";

        serviceCollection.AddDbContext<AppContext>(x =>
        {
            x.UseNpgsql($"Host={DbHost};Database={Database};Username={Username};Password={Password}");
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
