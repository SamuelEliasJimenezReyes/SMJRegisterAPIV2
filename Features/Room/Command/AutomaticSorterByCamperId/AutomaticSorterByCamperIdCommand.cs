using MediatR;

namespace SMJRegisterAPIV2.Features.Room.Command.AutomaticSorterByCamperId;

public class AutomaticSorterByCamperIdCommand : IRequest<Unit>
{
    public int CamperId { get; set; }
}