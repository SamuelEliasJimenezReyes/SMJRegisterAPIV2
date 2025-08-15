using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Room.Dtos;

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
    public string Gender { get; set; }

    
    public ICollection<CamperSimpleDto> Campers { get; set; }
}