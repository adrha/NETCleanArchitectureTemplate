using System.Runtime.Serialization;

namespace CityManager.Api.Contracts.OutputModel;

public record ActivityOutputModel
{
    [DataMember(Name="activity")]
    public string? Activity { get; init; }
    [DataMember(Name="participants")]
    public int? Participants { get; init; }
    [DataMember(Name="price")]
    public double? Price { get; init; }
    [DataMember(Name="type")]
    public string? Type { get; init; }
}