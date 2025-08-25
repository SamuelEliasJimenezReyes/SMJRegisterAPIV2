using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetByFilter;

public class GetCamperByFiltersQueryHandler(
    ICamperRepository repository,
    IMapper mapper) : IRequestHandler<GetCamperByFiltersQuery, IList<CamperSimpleDto>>
{
    public async Task<IList<CamperSimpleDto>> Handle(GetCamperByFiltersQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.FindByFilterAsync(request.Filter);
        var sortedList = list.OrderByDescending(x=>x.CreatedAt);
        return mapper.Map<IList<CamperSimpleDto>>(sortedList);
    }
}