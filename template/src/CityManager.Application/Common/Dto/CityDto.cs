using CityManager.Domain.Enum;

namespace CityManager.Application.Common.Dto;

public record CityDto
{
    public Guid? Id { get; set; }
    
    public string? Name { get; set; }
    
    public int BfsId { get; init; }
    
    public int CantonId { get; init; }
    
    public CityType CityType { get; init; }
}