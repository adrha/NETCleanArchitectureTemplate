using CityManager.Domain.Enum;

namespace CityManager.Application.Common.Dto;

public class CityDto
{
    public Guid? Id { get; set; }
    
    public string? Name { get; set; }
    
    public int BfsId { get; set; }
    
    public int CantonId { get; set; }
    
    public CityType CityType { get; set; }
}