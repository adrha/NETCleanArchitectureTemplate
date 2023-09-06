using AutoMapper;
using CityManager.Application.Common.Dto;
using CityManager.Application.Common.Interfaces.Repositories;
using CityManager.Application.Common.Interfaces.Services;
using CityManager.Application.Common.Options;
using CityManager.Domain.Entities;
using Microsoft.Extensions.Options;

namespace CityManager.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly CityManagerOptions _CityManagerOptions;
    private readonly IMapper _mapper;
    
    public CityService(ICityRepository cityRepository, IOptions<CityManagerOptions> options, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _CityManagerOptions = options.Value;
        _mapper = mapper;
    }
    
    public async Task<City> CreateCityAsync(CityDto city)
    {
        ApplyCityDefaultNameIfEmpty(ref city);

        if (city.Id == null || city.Id == Guid.Empty)
        {
            city.Id = Guid.NewGuid();
        }

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
            city.Name = _CityManagerOptions.DefaultCityName;
        }
    }
}