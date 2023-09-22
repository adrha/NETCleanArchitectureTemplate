using AutoMapper;
using CityManager.Application.Common.Dto;
using CityManager.Application.Common.Interfaces.Application.Services;
using CityManager.Application.Common.Interfaces.Infrastructure.Persistence.Repositories;
using CityManager.Application.Common.Options;
using CityManager.Domain.Entities;
using Microsoft.Extensions.Options;

namespace CityManager.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly CityManagerOptions _cityManagerOptions;
    private readonly IMapper _mapper;
    
    public CityService(ICityRepository cityRepository, IOptions<CityManagerOptions> options, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _cityManagerOptions = options.Value;
        _mapper = mapper;
    }
    
    public async Task<City> CreateCityAsync(CityDto city)
    {
        ApplyCityDefaultNameIfEmpty(ref city);

        var mapped = _mapper.Map<City>(city);
        return await _cityRepository.CreateCityAsync(mapped);
    }

    public async Task<City> UpdateCityAsync(CityDto city)
    {
        ApplyCityDefaultNameIfEmpty(ref city);

        var mapped = _mapper.Map<City>(city);
        return await _cityRepository.UpdateCityAsync(mapped);
    }

    private void ApplyCityDefaultNameIfEmpty(ref CityDto city)
    {
        if (string.IsNullOrWhiteSpace(city.Name))
        {
            city.Name = _cityManagerOptions.DefaultCityName;
        }
    }
}