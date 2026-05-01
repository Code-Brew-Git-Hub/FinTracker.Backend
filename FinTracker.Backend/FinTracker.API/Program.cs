using FinTracker.Data;
using FinTracker.Domain.Dtos.Universal;
using Mapster;
using Microsoft.AspNetCore.Diagnostics;

namespace FinTracker.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRepositories();
        builder.Services.AddServices();
        builder.Services.AddContext();

        MappingConfig.Configure();
        builder.Services.AddMapster();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();        

        var app = builder.Build();

        app.UseExceptionHandler(appBuilder => appBuilder.Run(async context =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                KeyNotFoundException ex => (StatusCodes.Status404NotFound, ex.Message),
                ArgumentException ex => (StatusCodes.Status400BadRequest, ex.Message),
                _ => (StatusCodes.Status500InternalServerError, "Internal server error")
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(ApiResponse<object>.Fail(message));
        }));

        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}
