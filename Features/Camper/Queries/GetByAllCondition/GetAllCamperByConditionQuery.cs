using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetByAllCondition;

public class GetAllCamperByConditionQuery : IRequest<List<CamperDTO>>
{
    public int Condition { get; set; }
}