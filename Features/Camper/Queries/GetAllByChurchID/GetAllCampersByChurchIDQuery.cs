using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;


namespace SMJRegisterAPI.Features.Camper.Queries.GetAllByChurchID;

public  class GetAllCampersByChurchIdQuery : IRequest<List<CamperDTO>>
{
    public int ChurchId { get; set; }
}