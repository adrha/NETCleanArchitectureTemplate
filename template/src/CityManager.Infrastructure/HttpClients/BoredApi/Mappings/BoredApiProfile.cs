using AutoMapper;
using CityManager.Application.Common.Dto;
using CityManager.Infrastructure.HttpClients.BoredApi.Models;

namespace CityManager.Infrastructure.HttpClients.BoredApi.Mappings;

public class BoredApiProfile : Profile
{
    public BoredApiProfile()
    {
        CreateMap<GetActivityResponse, ActivityDto>();
    }
}