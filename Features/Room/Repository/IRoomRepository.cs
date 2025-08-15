using SMJRegisterAPIV2.Entities.Enums;
using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Room.Repository;

public interface IRoomRepository : IGenericRepository<Entities.Room>
{
    Task<IEnumerable<Entities.Room>> GetAllRoomsWhitCamper();
    Task<Entities.Room> GetByIdWithCamper(int id);
    Task<IEnumerable<Entities.Room>> GetRoomsByGender(Gender gender); 
}