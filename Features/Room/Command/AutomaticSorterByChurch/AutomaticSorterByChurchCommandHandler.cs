using MediatR;
using SMJRegisterAPI.Features.Camper.Repository;
using SMJRegisterAPI.Features.Room.Repository;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Features.Room.Command.AutomaticSorterByChurch;

public class AutomaticSorterByChurchCommandHandler(IRoomRepository repository, ICamperRepository camperRepository) 
    : IRequestHandler<AutomaticSorterByChurchCommand, Unit>
{
    public async Task<Unit> Handle(AutomaticSorterByChurchCommand request, CancellationToken cancellationToken)
    {
        var campers = await camperRepository.GetAllByChurchIDAsync(request.ChurchId);
        var unassigned = campers.Where(x => x.RoomId is null or 0).ToList();

        var femaleRooms = await repository.GetRoomsByGender(Gender.Mujer);
        var maleRooms = await repository.GetRoomsByGender(Gender.Hombre);
        
        var females = unassigned.Where(c => c.Gender == Gender.Mujer).ToList();
        var males = unassigned.Where(c => c.Gender == Gender.Hombre).ToList();
        
        await AssignCampersToRooms(females, femaleRooms, camperRepository);
        await AssignCampersToRooms(males, maleRooms, camperRepository);

        return Unit.Value;
    }


    private async Task AssignCampersToRooms(
        List<Entities.Camper> campers,
        IEnumerable<Entities.Room> rooms,
        ICamperRepository camperRepository)
    {
        foreach (var camper in campers)
        {
            var availableRoom = rooms.FirstOrDefault(r => r.Campers.Count < r.MaxCapacity);

            if (availableRoom is not null)
            {
                camper.RoomId = availableRoom.ID;
                availableRoom.CurrentCapacity++;
                availableRoom.Campers.Add(camper);
                await camperRepository.UpdateAsync(camper, camper.ID);
            }
        }
    }
}