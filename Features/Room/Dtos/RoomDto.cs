using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Room.Dtos;

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public string Gender { get; set; }

    
    public ICollection<CamperSimpleDto> Campers { get; set; }
}