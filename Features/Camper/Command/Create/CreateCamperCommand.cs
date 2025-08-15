using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Command.Create;

public class CreateCamperCommand(CreateCamperDTO camper) : IRequest<CreateCamperDTO>
{
    public CreateCamperDTO Camper { get; set; } = camper;
}