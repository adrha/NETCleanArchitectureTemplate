using AutoMapper;
using CityManager.Api.Contracts;
using CityManager.Api.Contracts.OutputModel;
using CityManager.Application.Common.Interfaces.Application.Services;
using CityManager.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CityManager.Api.Controllers;

[ApiController]
public class ActivityController : CustomControllerBase
{
    private readonly IActivityService _activityService;
    private readonly IMapper _mapper;
    private readonly ILogger<ActivityController> _logger;

    public ActivityController(IActivityService activityService, IMapper mapper, ILogger<ActivityController> logger)
    {
        _activityService = activityService;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet(Routes.V1.Activities.RandomActivityRoute, Name = nameof(GetRandomActivity))]
    [SwaggerResponse(statusCode:200, type: typeof(ActivityOutputModel))]
    [SwaggerResponse(statusCode:400)]
    [SwaggerResponse(statusCode:404)]
    [SwaggerResponse(statusCode:500)]
    public async Task<IActionResult> GetRandomActivity()
    {
        try
        {
            var activity = await _activityService.GetRandomActivityAsync();
            var activityVm = _mapper.Map<ActivityOutputModel>(activity);
            return Ok(activityVm);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, "Could not get random activity");
            return NotFound("Could not get random activity");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get random activity");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}