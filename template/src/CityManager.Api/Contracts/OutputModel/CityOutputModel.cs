using System.Runtime.Serialization;
using CityManager.Api.Contracts.Enum;

namespace CityManager.Api.Contracts.OutputModel;

public record CityOutputModel
{
    [DataMember(Name="id")]
    public Guid Id { get; init; }
    
    [DataMember(Name="name")]
    public string? Name { get; init; }
    
    [DataMember(Name="bfsId")]
    public int BfsId { get; init; }
    
    [DataMember(Name="cantonId")]
    public int CantonId { get; init; }
    
    [DataMember(Name="cityType")]
    public CityType CityType { get; init; }
}