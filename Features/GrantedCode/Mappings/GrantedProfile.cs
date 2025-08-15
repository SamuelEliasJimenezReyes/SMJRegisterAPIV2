using AutoMapper;
using SMJRegisterAPI.Features.Camper.Command.Create;
using SMJRegisterAPI.Features.GrantedCode.Dtos;

namespace SMJRegisterAPI.Features.GrantedCode.Mappings;

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