using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Camper.Queries.GetByAllCondition;

public class GetAllCamperByConditionQuery : IRequest<List<CamperDTO>>
{
    public int Condition { get; set; }
}