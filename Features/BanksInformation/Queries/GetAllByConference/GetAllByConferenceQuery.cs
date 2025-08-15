using MediatR;
using SMJRegisterAPI.Features.BanksInformation.Dtos;

namespace SMJRegisterAPI.Features.BanksInformation.Queries.GetAllByConference;

public class GetAllByConferenceQuery : IRequest<IList<BankInformationDto>> 
{
    public int Conference { get; set; }
}