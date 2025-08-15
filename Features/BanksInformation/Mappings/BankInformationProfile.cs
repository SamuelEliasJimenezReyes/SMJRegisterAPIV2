using AutoMapper;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;

namespace SMJRegisterAPIV2.Features.BanksInformation.Mappings;

public class BankInformationProfile : Profile
{
    public BankInformationProfile()
    {
        CreateMap<Entities.BanksInformation, BankInformationDto>();
        CreateMap<BankInformationDto, Entities.BanksInformation>();
    }
}