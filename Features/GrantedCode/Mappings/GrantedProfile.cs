using AutoMapper;
using SMJRegisterAPIV2.Features.Camper.Command.Create;
using SMJRegisterAPIV2.Features.GrantedCode.Dtos;

namespace SMJRegisterAPIV2.Features.GrantedCode.Mappings;

public class GrantedProfile : Profile
{
    public GrantedProfile()
    {
        CreateMap<GrantedCodeSimpleDTO, Entities.GrantedCode>();
        CreateMap<Entities.GrantedCode,GrantedCodeSimpleDTO>();

        CreateMap<GrantedCodeDTO, Entities.GrantedCode>();
        CreateMap<Entities.GrantedCode, GrantedCodeDTO>();
        
        CreateMap<CreateGrantedCodeDTO,Entities.GrantedCode>();
        CreateMap<Entities.GrantedCode, CreateGrantedCodeDTO>();
    }
}