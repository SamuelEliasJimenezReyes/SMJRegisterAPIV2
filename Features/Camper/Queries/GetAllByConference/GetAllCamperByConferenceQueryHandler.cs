using AutoMapper;
using MediatR;
using SMJRegisterAPI.Entities.Enums;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.Camper.Repository;

namespace SMJRegisterAPI.Features.Camper.Queries.GetAllByConference;

public class GetAllCamperByConferenceQueryHandler(IMapper mapper, ICamperRepository repository) : IRequestHandler<GetAllCamperByConferenceQuery, List<CamperDTO>>
{
    public async Task<List<CamperDTO>> Handle(GetAllCamperByConferenceQuery request, CancellationToken cancellationToken)
    {

        var list = await repository.GetAllAsync();
        var filteredList = list.Where(c => c.Church.Conference == (Conference)request.Conference).ToList();
        return mapper.Map<List<CamperDTO>>(filteredList);
    }
}