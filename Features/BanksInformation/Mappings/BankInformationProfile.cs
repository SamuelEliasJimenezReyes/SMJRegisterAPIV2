using AutoMapper;
using SMJRegisterAPI.Features.BanksInformation.Dtos;

namespace SMJRegisterAPI.Features.BanksInformation.Mappings;

public class BankInformationProfile : Profile
{
    public BankInformationProfile()
    {
        CreateMap<Entities.BanksInformation, BankInformationDto>();
        CreateMap<BankInformationDto, Entities.BanksInformation>();
    }
}