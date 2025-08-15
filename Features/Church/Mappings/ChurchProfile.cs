using AutoMapper;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.Church.Dtos;

namespace SMJRegisterAPI.Features.Church.Mappings;

public class ChurchProfile : Profile
{
    public ChurchProfile()
    {
        CreateMap<Entities.Church, ChurchDTO>();
        
        CreateMap<Entities.Church, ChurchSimpleDTO>();
    }
}