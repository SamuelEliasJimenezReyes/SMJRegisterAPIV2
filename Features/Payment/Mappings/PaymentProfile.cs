using AutoMapper;
using SMJRegisterAPI.Features.Payment.Dtos;

namespace SMJRegisterAPI.Features.Payment.Mappings;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<PaymentDto, Entities.Payment>();
        CreateMap<Entities.Payment, PaymentDto>()
            .ForMember(dest =>dest.BanksInformation ,
                opt => opt
                .MapFrom(src => src.BanksInformation))
            .ForMember(dest =>dest.Camper ,
                opt => opt
                .MapFrom(src => src.Camper));

        CreateMap<CreatePaymentDto, Entities.Payment>();
        CreateMap<Entities.Payment, CreatePaymentDto>();
        
    }
}