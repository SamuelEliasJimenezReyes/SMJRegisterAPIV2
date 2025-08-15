using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Entities.Enums;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetByAllCondition;

public class GetAllCamperByConditionQueryHandler (IMapper mapper, ICamperRepository repository) : IRequestHandler<GetAllCamperByConditionQuery, List<CamperDTO>>
{
    public async Task<List<CamperDTO>> Handle(GetAllCamperByConditionQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        var filteredList = list.Where(x=>x.Condition==(Condition)request.Condition).ToList();
        return mapper.Map<List<CamperDTO>>(filteredList);
    }
}