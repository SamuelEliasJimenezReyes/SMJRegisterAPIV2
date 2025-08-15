namespace SMJRegisterAPI.Features.Room.Dtos;

public class CreateRoomDto
{
    public string Name { get; set; }
    public int MaxCapacity { get; set; } 
    public int Gender { get; set; }

}