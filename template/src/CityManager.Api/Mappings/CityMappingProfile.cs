using CityManager.Api.Contracts.InputModel;
using CityManager.Api.Contracts.OutputModel;
using CityManager.Domain.Entities;

using AutoMapper;
using CityManager.Application.Common.Dto;

namespace CityManager.Api.Mappings;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        CreateMap<CityInputModel, City>()
            ;

        CreateMap<CityInputModel, CityDto>()
            ;

        CreateMap<City, CityOutputModel>()
            ;
    }
}