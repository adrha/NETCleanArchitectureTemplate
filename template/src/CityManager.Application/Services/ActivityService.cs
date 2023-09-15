using CityManager.Application.Common.Dto;
using CityManager.Application.Common.Interfaces.Application.Services;
using CityManager.Application.Common.Interfaces.Infrastructure.HttpClients.BoredApi;

namespace CityManager.Application.Services;

public class ActivityService : IActivityService
{
    private readonly IBoredApiClient _boredApiClient;

    public ActivityService(IBoredApiClient boredApiClient)
    {
        _boredApiClient = boredApiClient;
    }
    
    public async Task<ActivityDto> GetRandomActivityAsync()
    {
        return await _boredApiClient.GetRandomActivityAsync();
    }
}