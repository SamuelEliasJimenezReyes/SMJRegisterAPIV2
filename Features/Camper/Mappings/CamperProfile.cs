using AutoMapper;
using SMJRegisterAPIV2.Features.Camper.Command.Create;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Mappings;

public class CamperProfile : Profile
{
    public CamperProfile()
    {
        CreateMap<Entities.Camper, CamperDTO>()
            .ForMember(dest=>dest.Church, opt
                =>opt.MapFrom(
                    src=>src.Church))
            .ForMember(dest=>dest.GrantedCode, opt=>opt.MapFrom(
                src=>src.GrantedCode))
            .ForMember(dest=>dest.Room,opt=>opt.MapFrom(
                src=>src.Room));
        
        CreateMap<Entities.Camper, CreateCamperDTO>();
        
        CreateMap<Entities.Camper, CamperSimpleDto>()
            .ForMember(dest=>dest.Church,
                opt=>opt.MapFrom(
                src=>src.Church));

        CreateMap<CreateCamperDTO, Entities.Camper>();
        CreateMap<CreateCamperCommand , Entities.Camper>();
        
        CreateMap<Entities.Camper, UpdateCamperDTO>();

        CreateMap<UpdateCamperDTO, Entities.Camper>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
            .ForMember(dest => dest.DocumentsURL, opt => opt.Ignore())
            .ForMember(dest => dest.TotalAmount, opt => opt.Ignore())
            .ForMember(dest => dest.GrantedCodeId, opt => opt.Ignore())
            .ForMember(dest => dest.ArrivedTimeSlot, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
    }
    
}