using CityManager.Application.Common.Dto;

namespace CityManager.Application.Common.Interfaces.Application.Services;

public interface IActivityService
{
    Task<ActivityDto> GetRandomActivityAsync();
}