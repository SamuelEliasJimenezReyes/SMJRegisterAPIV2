using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetAll;

public class GetAllCampersQuery : IRequest<IList<CamperSimpleDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}