using Microsoft.EntityFrameworkCore;
using SMJRegisterAPI.Database.Contexts;
using SMJRegisterAPI.Features.Common;

namespace SMJRegisterAPI.Features.Room.Repository;

public class RoomRepository(ApplicationDbContext context) : GenericRepository<Entities.Room>(context), IRoomRepository
{

    public async Task<IEnumerable<Entities.Room>> GetAllRoomsWhitCamper()
    {
        return await context.Rooms
            .Include(x => x.Campers)
            .ToListAsync();
    }

    public async Task<Entities.Room> GetByIdWithCamper(int id)
    {
        return await context.Rooms
            .Include(x => x.Campers)
            .FirstOrDefaultAsync(x=>x.ID == id);
    }
    
    public async Task<IEnumerable<Entities.Room>> GetRoomsByGender(Entities.Enums.Gender gender)
    {
        return await context.Rooms
            .Include(x => x.Campers)
            .Where(x => x.Gender == gender)
            .ToListAsync();
    }
}