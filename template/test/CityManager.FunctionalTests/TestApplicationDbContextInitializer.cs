using CityManager.Application.Common.Interfaces;
using CityManager.Domain.Entities;
using CityManager.Infrastructure.Persistence;
using Newtonsoft.Json;

namespace CityManager.FunctionalTests;

public class TestApplicationDbContextInitializer : IApplicationDbContextInitializer
{
    private const string TestDataBasePath = @"./TestData/";
    private const string CitySampleDataFilePath = TestDataBasePath + "Cities.json";
    
    private readonly ApplicationDbContext _context;
    
    public TestApplicationDbContextInitializer(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Task InitializeAsync()
    {
        // Nothing to do here...
        return Task.CompletedTask;
    }

    public async Task SeedAsync()
    {
        await LoadDataAsync<City>(CitySampleDataFilePath);
    }

    private async Task LoadDataAsync<T>(string file) where T : EntityBase
    {
        string fileContent = await File.ReadAllTextAsync(file);
        List<T>? items = JsonConvert.DeserializeObject<List<T>>(fileContent);

        if (items == null || items.Count == 0)
        {
            return;
        }

        await _context.AddRangeAsync(items);
        await _context.SaveChangesAsync();
    }
}