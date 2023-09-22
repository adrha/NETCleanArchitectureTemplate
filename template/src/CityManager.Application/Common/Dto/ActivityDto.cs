namespace CityManager.Application.Common.Dto;

public record ActivityDto
{
    public string? Activity { get; init; }
    public int? Participants { get; init; }
    public double? Price { get; init; }
    public string? Type { get; init; }
}