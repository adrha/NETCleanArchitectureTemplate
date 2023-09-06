using CityManager.Domain.Entities;

using AutoMapper;
using CityManager.Application.Common.Dto;

namespace CityManager.Application.Mappings;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        CreateMap<CityDto, City>()
            ;
    }
}