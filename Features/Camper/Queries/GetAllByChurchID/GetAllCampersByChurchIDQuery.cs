using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;


namespace SMJRegisterAPIV2.Features.Camper.Queries.GetAllByChurchID;

public  class GetAllCampersByChurchIdQuery : IRequest<List<CamperDTO>>
{
    public int ChurchId { get; set; }
}