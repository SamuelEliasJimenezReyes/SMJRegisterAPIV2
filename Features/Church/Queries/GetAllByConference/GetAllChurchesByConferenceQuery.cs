using MediatR;
using SMJRegisterAPIV2.Features.Church.Dtos;

namespace SMJRegisterAPIV2.Features.Church.Queries.GetAllByConference;

public class GetAllChurchesByConferenceQuery : IRequest<IList<ChurchSimpleDTO>>
{
    public int Conference { get; set; }
}