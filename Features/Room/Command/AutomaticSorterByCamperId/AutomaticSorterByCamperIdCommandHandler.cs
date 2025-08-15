using MediatR;
using SMJRegisterAPI.Features.Camper.Repository;
using SMJRegisterAPI.Features.Room.Repository;

namespace SMJRegisterAPI.Features.Room.Command.AutomaticSorterByCamperId;

public class AutomaticSorterByCamperIdCommandHandler (IRoomRepository repository, ICamperRepository camperRepository)
    : IRequestHandler<AutomaticSorterByCamperIdCommand, Unit>
{
    public async Task<Unit> Handle(AutomaticSorterByCamperIdCommand request, CancellationToken cancellationToken)
    {
        var camper = await camperRepository.GetByIdAsync(request.CamperId);

        var rooms = await repository.GetAllRoomsWhitCamper();
        var availableRoom = rooms.FirstOrDefault(r=>r.Campers.Count < r.MaxCapacity);
        var females = rooms.Where(r => r.Campers.Count < r.MaxCapacity);
        if (availableRoom is not null)
        {
            camper.RoomId = availableRoom.ID;
            availableRoom.CurrentCapacity++;
            availableRoom.Campers.Add(camper);
            await camperRepository.UpdateAsync(camper, request.CamperId);
        }
        return Unit.Value;
    }
}