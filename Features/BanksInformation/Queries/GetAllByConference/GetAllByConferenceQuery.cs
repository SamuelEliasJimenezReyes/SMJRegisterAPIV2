using MediatR;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;

namespace SMJRegisterAPIV2.Features.BanksInformation.Queries.GetAllByConference;

public class GetAllByConferenceQuery : IRequest<IList<BankInformationDto>> 
{
    public int Conference { get; set; }
}