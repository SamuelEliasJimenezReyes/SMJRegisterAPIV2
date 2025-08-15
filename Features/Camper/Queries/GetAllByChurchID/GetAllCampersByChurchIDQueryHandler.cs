using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetAllByChurchID;

public class GetAllCampersByChurchIdQueryHandler(IMapper mapper, ICamperRepository repository)
    : IRequestHandler<GetAllCampersByChurchIdQuery, List<CamperDTO>>
{

    public async Task<List<CamperDTO>> Handle(GetAllCampersByChurchIdQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllByChurchIDAsync(request.ChurchId);
        return mapper.Map<List<CamperDTO>>(list);
    }
}