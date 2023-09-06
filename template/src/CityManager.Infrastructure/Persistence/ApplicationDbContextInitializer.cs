using CityManager.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CityManager.Infrastructure.Persistence;

public class ApplicationDbContextInitializer : IApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger,
        ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task InitializeAsync()
    {
        try
        {
            if (_applicationDbContext.Database.IsNpgsql())
            {
                _logger.LogInformation("Pending migrations:");
                foreach (string pendingMigration in await _applicationDbContext.Database.GetPendingMigrationsAsync())
                {
                    _logger.LogInformation($"\t-> {pendingMigration}");
                }
                
                _logger.LogInformation("Applying pending migrations...");
                await _applicationDbContext.Database.MigrateAsync();
                _logger.LogInformation("Database migration done");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured while initializing the database.");
            throw;
        }
    }

    public Task SeedAsync()
    {
        return Task.CompletedTask;
    }
}