namespace CityManager.Application.Common.Options;

public record CityManagerOptions
{
    public const string OptionPosition = "CityManagerOptions";
    
    public string? DefaultCityName { get; init; }
}