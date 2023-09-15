using System.Reflection;
using CityManager.Application.Common.Interfaces.Application.Services;
using CityManager.Application.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityManager.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IActivityService, ActivityService>();
        
        return services;
    }
}