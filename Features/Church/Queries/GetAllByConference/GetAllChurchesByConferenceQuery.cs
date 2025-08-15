using MediatR;
using SMJRegisterAPI.Features.Church.Dtos;

namespace SMJRegisterAPI.Features.Church.Queries.GetAllByConference;

public class GetAllChurchesByConferenceQuery : IRequest<IList<ChurchSimpleDTO>>
{
    public int Conference { get; set; }
}