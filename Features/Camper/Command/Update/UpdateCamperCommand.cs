using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Camper.Command.Update;

public class UpdateCamperCommand(UpdateCamperDTO camper, int id) : IRequest<UpdateCamperDTO>
{
    public int Id { get; set; } = id;
    public UpdateCamperDTO Camper { get; set; } = camper;
}