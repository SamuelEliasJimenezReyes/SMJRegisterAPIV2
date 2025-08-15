using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Command.Update;

public class UpdateCamperCommand(UpdateCamperDTO camper, int id) : IRequest<UpdateCamperDTO>
{
    public int Id { get; set; } = id;
    public UpdateCamperDTO Camper { get; set; } = camper;
}