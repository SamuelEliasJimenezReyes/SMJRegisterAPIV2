using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Camper.Queries.GetAllByConference;

public class GetAllCamperByConferenceQuery : IRequest<List<CamperDTO>>
{
    public int Conference { get; set; }
}