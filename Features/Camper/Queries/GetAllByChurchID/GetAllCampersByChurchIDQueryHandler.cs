using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.Camper.Repository;

namespace SMJRegisterAPI.Features.Camper.Queries.GetAllByChurchID;

public class GetAllCampersByChurchIdQueryHandler(IMapper mapper, ICamperRepository repository)
    : IRequestHandler<GetAllCampersByChurchIdQuery, List<CamperDTO>>
{

    public async Task<List<CamperDTO>> Handle(GetAllCampersByChurchIdQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllByChurchIDAsync(request.ChurchId);
        return mapper.Map<List<CamperDTO>>(list);
    }
}