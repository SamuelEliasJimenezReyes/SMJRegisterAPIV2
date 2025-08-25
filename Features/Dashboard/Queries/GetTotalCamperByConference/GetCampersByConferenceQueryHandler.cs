using MediatR;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Dashboard.Dtos;

namespace SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalCamperByConference;

public class GetCampersByConferenceQueryHandler(ApplicationDbContext context) : IRequestHandler<GetCampersByConferenceQuery, IList<GetCampersByConferenceDto>>
{
    public async Task<IList<GetCampersByConferenceDto>> Handle(GetCampersByConferenceQuery request, CancellationToken cancellationToken)
    {
        return await context.Campers.GroupBy(c=>c.Church.Conference)
            .Select(g=> new GetCampersByConferenceDto
            {
                Conference = g.Key.ToString(),
                CamperCount = g.Count()
            }).ToListAsync(cancellationToken);
    }
}