using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetByFilter;

public class GetCamperByFiltersQuery : IRequest<IList<CamperSimpleDto>>
{
    public string Filter { get; set; }
}