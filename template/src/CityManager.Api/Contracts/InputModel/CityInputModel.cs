using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CityManager.Api.Contracts.Enum;

namespace CityManager.Api.Contracts.InputModel;

public class CityInputModel
{
    [DataMember(Name="name")]
    public string? Name { get; set; }
    
    [Required]
    [DataMember(Name="bfsId")]
    public int BfsId { get; set; }
    
    [Required]
    [DataMember(Name="cantonId")]
    public int CantonId { get; set; }
    
    [Required]
    [DataMember(Name="cityType")]
    public CityType CityType { get; set; }
}