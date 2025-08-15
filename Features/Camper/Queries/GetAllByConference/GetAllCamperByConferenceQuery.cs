using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetAllByConference;

public class GetAllCamperByConferenceQuery : IRequest<List<CamperDTO>>
{
    public int Conference { get; set; }
}