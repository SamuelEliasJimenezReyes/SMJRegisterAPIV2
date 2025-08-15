using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetById;

public class GetCamperByIdQuery : IRequest<CamperDTO>
{
    public int ID { get; set; }
}