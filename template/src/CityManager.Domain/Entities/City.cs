using CityManager.Domain.Enum;

namespace CityManager.Domain.Entities;

public class City
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public bool IsActive { get; set; }
    
    public CityType CityType { get; set; }
    
    public int? BfsId { get; set; }
    
    public int? CantonId { get; set; }
    
    public DateTime Created { get; set; }
}