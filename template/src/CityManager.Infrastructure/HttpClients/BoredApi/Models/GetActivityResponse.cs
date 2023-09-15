namespace CityManager.Infrastructure.HttpClients.BoredApi.Models;

public record GetActivityResponse
{
    public double? Accessibility { get; init; }
    public string? Activity { get; init; }
    public string? Key { get; init; }
    public string? Link { get; init; }
    public int? Participants { get; init; }
    public double? Price { get; init; }
    public string? Type { get; init; }
}