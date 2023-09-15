namespace CityManager.Application.Common.Options;

public record ActivityOptions
{
    public const string OptionPosition = "ActivityOptions";
    
    public string? BoredApiRoot { get; init; }
    public string? ActivityEndpoint { get; init; }
}