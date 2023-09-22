using CityManager.Application.Common.Dto;

namespace CityManager.Application.Common.Interfaces.Infrastructure.HttpClients.BoredApi;

public interface IBoredApiClient
{
    Task<ActivityDto> GetRandomActivityAsync();
}