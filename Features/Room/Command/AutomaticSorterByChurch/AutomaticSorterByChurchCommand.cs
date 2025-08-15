using MediatR;

namespace SMJRegisterAPI.Features.Room.Command.AutomaticSorterByChurch;

public class AutomaticSorterByChurchCommand : IRequest<Unit>
{
    public int ChurchId { get; set; }
}