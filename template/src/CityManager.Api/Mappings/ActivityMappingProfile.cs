using AutoMapper;
using CityManager.Api.Contracts.OutputModel;
using CityManager.Application.Common.Dto;

namespace CityManager.Api.Mappings;

public class ActivityMappingProfile : Profile
{
    public ActivityMappingProfile()
    {
        CreateMap<ActivityDto, ActivityOutputModel>();
    }
}