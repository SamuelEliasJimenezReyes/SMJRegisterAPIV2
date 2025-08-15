using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Camper.Queries.GetAll;

public class GetAllCampersQuery : IRequest<IList<CamperSimpleDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}