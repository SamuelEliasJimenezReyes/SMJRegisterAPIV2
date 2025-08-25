using MediatR;
using SMJRegisterAPIV2.Features.Dashboard.Dtos;

namespace SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalCamperByConference;

public class GetCampersByConferenceQuery : IRequest<IList<GetCampersByConferenceDto>>
{
    
}