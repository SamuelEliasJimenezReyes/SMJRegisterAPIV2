using AutoMapper;
using MediatR;
using SMJRegisterAPI.Entities.Enums;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.Camper.Repository;

namespace SMJRegisterAPI.Features.Camper.Queries.GetByAllCondition;

public class GetAllCamperByConditionQueryHandler (IMapper mapper, ICamperRepository repository) : IRequestHandler<GetAllCamperByConditionQuery, List<CamperDTO>>
{
    public async Task<List<CamperDTO>> Handle(GetAllCamperByConditionQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        var filteredList = list.Where(x=>x.Condition==(Condition)request.Condition).ToList();
        return mapper.Map<List<CamperDTO>>(filteredList);
    }
}