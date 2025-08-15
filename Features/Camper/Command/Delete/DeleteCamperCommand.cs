using MediatR;

namespace SMJRegisterAPIV2.Features.Camper.Command.Delete;

public class DeleteCamperCommand : IRequest<bool>
{
    public int Id { get; set; }
}