using System.Runtime.Serialization;

namespace CityManager.Api.Contracts.OutputModel;

public class CityOutputModel
{
    [DataMember(Name="id")]
    public Guid Id { get; set; }
    
    [DataMember(Name="name")]
    public string Name { get; set; }
    
    [DataMember(Name="bfsId")]
    public int BfsId { get; set; }
    
    [DataMember(Name="cantonId")]
    public int CantonId { get; set; }
}