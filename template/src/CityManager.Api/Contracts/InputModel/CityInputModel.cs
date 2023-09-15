using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CityManager.Api.Contracts.Enum;

namespace CityManager.Api.Contracts.InputModel;

public record CityInputModel
{
    [DataMember(Name="name")]
    public string? Name { get; init; }
    
    [Required]
    [DataMember(Name="bfsId")]
    public int BfsId { get; init; }
    
    [Required]
    [DataMember(Name="cantonId")]
    public int CantonId { get; init; }
    
    [Required]
    [DataMember(Name="cityType")]
    public CityType CityType { get; init; }
}