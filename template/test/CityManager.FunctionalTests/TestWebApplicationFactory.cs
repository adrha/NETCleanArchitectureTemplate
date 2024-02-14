using CityManager.Application.Common.Interfaces;
using CityManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityManager.FunctionalTests;

public class TestWebApplicationFactory <TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    private const string FunctionalTestEnvironmentName = "Testing";
    private readonly Guid _inMemoryDatabaseId = Guid.NewGuid();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            ServiceDescriptor? dbContextDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            services.Remove(dbContextDescriptor!);
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Each test class gets it's own database with a new set of test data
                options.UseInMemoryDatabase($"CityManager.API.{_inMemoryDatabaseId}");
            });
            
            services.AddScoped<IApplicationDbContextInitializer, TestApplicationDbContextInitializer>();
        });
        
        builder.UseEnvironment(FunctionalTestEnvironmentName);
        builder.UseConfiguration(new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"appsettings.{FunctionalTestEnvironmentName}.json"))
            .Build());
    }
}
