namespace CityManager.Application.Common.Interfaces;

public interface IApplicationDbContextInitializer
{
    Task InitializeAsync();
    Task SeedAsync();
}