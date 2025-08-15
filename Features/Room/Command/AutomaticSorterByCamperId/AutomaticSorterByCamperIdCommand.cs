using MediatR;

namespace SMJRegisterAPI.Features.Room.Command.AutomaticSorterByCamperId;

public class AutomaticSorterByCamperIdCommand : IRequest<Unit>
{
    public int CamperId { get; set; }
}