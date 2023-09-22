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
        throw new NotImplementedException();
    }

    public async Task SeedAsync()
    {
        await LoadDataAsync<City>(CitySampleDataFilePath);
    }

    private async Task LoadDataAsync<T>(string file)
    {
        string fileContent = await File.ReadAllTextAsync(file);
        List<T>? items = JsonConvert.DeserializeObject<List<T>>(fileContent);

        if (items == null || items.Count == 0)
        {
            return;
        }

        switch (items)
        {
            case List<City> cities:
                await _context.Cities.AddRangeAsync(cities);
                break;

            default:
                throw new NotImplementedException($"Adding items of type {items.GetType()} not supported yet!");
        }
        
        await _context.SaveChangesAsync();
    }
}