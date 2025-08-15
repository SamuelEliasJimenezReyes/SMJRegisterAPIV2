using MediatR;

namespace SMJRegisterAPIV2.Features.Room.Command.AutomaticSorterByChurch;

public class AutomaticSorterByChurchCommand : IRequest<Unit>
{
    public int ChurchId { get; set; }
}