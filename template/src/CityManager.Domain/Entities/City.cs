using CityManager.Domain.Enum;

namespace CityManager.Domain.Entities;

public record City
{
    public Guid Id { get; init; }
    
    public string? Name { get; init; }
    
    public bool IsActive { get; init; }
    
    public CityType CityType { get; init; }
    
    public int? BfsId { get; init; }
    
    public int? CantonId { get; init; }
    
    public DateTime Created { get; init; }
}