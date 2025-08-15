using AutoMapper;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Church.Dtos;

namespace SMJRegisterAPIV2.Features.Church.Mappings;

public class ChurchProfile : Profile
{
    public ChurchProfile()
    {
        CreateMap<Entities.Church, ChurchDTO>();
        
        CreateMap<Entities.Church, ChurchSimpleDTO>();
    }
}