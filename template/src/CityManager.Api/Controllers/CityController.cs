using CityManager.Api.Contracts;
using CityManager.Api.Contracts.InputModel;
using CityManager.Api.Contracts.OutputModel;
using CityManager.Application.Common.Dto;
using CityManager.Application.Exceptions;

using AutoMapper;
using CityManager.Application.Common.Interfaces.Application.Services;
using CityManager.Application.Common.Interfaces.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CityManager.Api.Controllers;

[ApiController]
public class CityController : CustomControllerBase
{
    private readonly ICityService _cityService;
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CityController> _logger;
    
    public CityController(ICityService cityService, ICityRepository cityRepository, IMapper mapper, ILogger<CityController> logger)
    {
        _cityService = cityService;
        _cityRepository = cityRepository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet(Routes.V1.Cities.CityRoute, Name = nameof(GetCityByIdAsync))]
    [SwaggerResponse(statusCode:200, type: typeof(CityOutputModel))]
    [SwaggerResponse(statusCode:400)]
    [SwaggerResponse(statusCode:404)]
    [SwaggerResponse(statusCode:500)]
    public async Task<IActionResult> GetCityByIdAsync(Guid id)
    {
        try
        {
            var cityEntity = await _cityRepository.GetCityByIdAsync(id);
            var cityVm = _mapper.Map<CityOutputModel>(cityEntity);
            return Ok(cityVm);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, $"Could not get city with ID {id}");
            return NotFound($"City with ID {id} not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get cities");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    [HttpGet(Routes.V1.Cities.CitiesRoute, Name = nameof(GetCitiesAsync))]
    [SwaggerResponse(statusCode:200, type: typeof(List<CityOutputModel>))]
    [SwaggerResponse(statusCode:400)]
    [SwaggerResponse(statusCode:500)]
    public async Task<IActionResult> GetCitiesAsync()
    {
        try
        {
            var cityEntities = await _cityRepository.GetCitiesAsync();
            var citiesVm = _mapper.Map<List<CityOutputModel>>(cityEntities);
            return Ok(citiesVm);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get cities");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
    
    [HttpPost(Routes.V1.Cities.CitiesRoute)]
    [SwaggerResponse(statusCode: 201, type: typeof(CityOutputModel))]
    [SwaggerResponse(statusCode: 400)]
    [SwaggerResponse(statusCode: 500)]
    public async Task<IActionResult> CreateCityAsync(CityInputModel input)
    {
        try
        {
            var cityDto = _mapper.Map<CityDto>(input);
            var cityEntity = await _cityService.CreateCityAsync(cityDto);
            var cityVm = _mapper.Map<CityOutputModel>(cityEntity);
            return CreatedAtRoute(routeName: nameof(GetCityByIdAsync), routeValues: new { id = cityVm.Id }, value: cityVm);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not create city");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    [HttpPut(Routes.V1.Cities.CityRoute)]
    [SwaggerResponse(statusCode:200, type: typeof(CityOutputModel))]
    [SwaggerResponse(statusCode:400)]
    [SwaggerResponse(statusCode:404)]
    [SwaggerResponse(statusCode:500)]
    public async Task<IActionResult> UpdateCityAsync(Guid id, [FromBody]CityInputModel input)
    {
        try
        {
            var cityDto = _mapper.Map<CityDto>(input);
            cityDto.Id = id;
            var cityEntity = await _cityService.UpdateCityAsync(cityDto);
            var cityVm = _mapper.Map<CityOutputModel>(cityEntity);
            return Ok(cityVm);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, $"Could not update city with ID {id}");
            return NotFound($"City with ID {id} not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not update city");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }

    [HttpDelete(Routes.V1.Cities.CityRoute)]
    [SwaggerResponse(statusCode:202)]
    [SwaggerResponse(statusCode:404)]
    [SwaggerResponse(statusCode:500)]
    public async Task<IActionResult> DeleteCityAsync(Guid id)
    {
        try
        {
            await _cityRepository.DeleteCityAsync(id);
            return Accepted();
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, $"Could not delete city with ID {id}");
            return NotFound($"City with ID {id} not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not delete city");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}