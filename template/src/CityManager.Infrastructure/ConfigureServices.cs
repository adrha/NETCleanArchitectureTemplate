using CityManager.Application.Common.Interfaces;
using CityManager.Infrastructure.Persistence;
using System.Reflection;
using CityManager.Application.Common.Interfaces.Infrastructure.HttpClients.BoredApi;
using CityManager.Application.Common.Interfaces.Infrastructure.Persistence.Repositories;
using CityManager.Infrastructure.HttpClients.BoredApi;
using CityManager.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CityManager.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration?.GetConnectionString("DefaultConnection") ?? "";
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IApplicationDbContextInitializer, ApplicationDbContextInitializer>();
        services.AddScoped<ICityRepository, CityRepository>();

        services.AddScoped<IBoredApiClient, BoredApiClient>();

        return services;
    }
}