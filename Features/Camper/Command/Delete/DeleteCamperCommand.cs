using MediatR;

namespace SMJRegisterAPI.Features.Camper.Command.Delete;

public class DeleteCamperCommand : IRequest<bool>
{
    public int Id { get; set; }
}