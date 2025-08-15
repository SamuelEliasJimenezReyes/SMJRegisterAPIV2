using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Camper.Command.Create;

public class CreateCamperCommand(CreateCamperDTO camper) : IRequest<CreateCamperDTO>
{
    public CreateCamperDTO Camper { get; set; } = camper;
}