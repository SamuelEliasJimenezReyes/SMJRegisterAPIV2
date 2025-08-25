using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetAll;

public class GetAllCampersQueryHandler(ICamperRepository repository, IMapper mapper)
    : IRequestHandler<GetAllCampersQuery, IList<CamperSimpleDto>>
{
    public async Task<IList<CamperSimpleDto>> Handle(GetAllCampersQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        var sortedList =  list.OrderByDescending(x => x.CreatedAt);
        return  mapper.Map<IList<CamperSimpleDto>>(sortedList);
    }
}