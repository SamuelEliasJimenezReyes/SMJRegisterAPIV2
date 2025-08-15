using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Entities.Enums;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetAllByConference;

public class GetAllCamperByConferenceQueryHandler(IMapper mapper, ICamperRepository repository) : IRequestHandler<GetAllCamperByConferenceQuery, List<CamperDTO>>
{
    public async Task<List<CamperDTO>> Handle(GetAllCamperByConferenceQuery request, CancellationToken cancellationToken)
    {

        var list = await repository.GetAllAsync();
        var filteredList = list.Where(c => c.Church.Conference == (Conference)request.Conference).ToList();
        return mapper.Map<List<CamperDTO>>(filteredList);
    }
}