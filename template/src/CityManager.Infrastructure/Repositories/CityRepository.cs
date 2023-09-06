using CityManager.Application.Common.Interfaces.Repositories;
using CityManager.Application.Exceptions;
using CityManager.Domain.Entities;
using CityManager.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace CityManager.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public CityRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<City> GetCityByIdAsync(Guid id)
    {
        City? city = await _dbContext.Cities
            .SingleOrDefaultAsync(c => c.Id == id);

        if (city is null)
        {
            throw new NotFoundException($"The city with ID {id} could not be found");
        }

        return city;
    }

    public async Task<IList<City>> GetCitiesAsync()
    {
        return await _dbContext.Cities.ToListAsync();
    }

    public async Task<City> CreateCityAsync(City city)
    {
        _dbContext.Cities.Add(city);
        await _dbContext.SaveChangesAsync();
        return await GetCityByIdAsync(city.Id);
    }

    public async Task<City> UpdateCityAsync(City city)
    {
        _dbContext.Cities.Update(city);
        await _dbContext.SaveChangesAsync();
        return await GetCityByIdAsync(city.Id);
    }

    public async Task DeleteCityAsync(Guid id)
    {
        City city = await GetCityByIdAsync(id);
        _dbContext.Remove(city);
        await _dbContext.SaveChangesAsync();
    }
}