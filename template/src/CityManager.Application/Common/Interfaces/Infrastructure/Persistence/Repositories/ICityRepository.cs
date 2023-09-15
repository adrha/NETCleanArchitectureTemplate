using CityManager.Domain.Entities;

namespace CityManager.Application.Common.Interfaces.Infrastructure.Persistence.Repositories;

public interface ICityRepository
{
    Task<City> GetCityByIdAsync(Guid id);
    Task<IList<City>> GetCitiesAsync();
    Task<City> CreateCityAsync(City city);
    Task<City> UpdateCityAsync(City city);
    Task DeleteCityAsync(Guid id);
}