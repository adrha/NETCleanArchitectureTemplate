using CityManager.Application.Common.Dto;
using CityManager.Domain.Entities;

namespace CityManager.Application.Common.Interfaces.Services;

public interface ICityService
{
    Task<City> CreateCityAsync(CityDto city);
    Task<City> UpdateCityAsync(CityDto city);
}