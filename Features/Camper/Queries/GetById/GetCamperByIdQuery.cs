using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Camper.Queries.GetById;

public class GetCamperByIdQuery : IRequest<CamperDTO>
{
    public int ID { get; set; }
}