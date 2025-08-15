namespace SMJRegisterAPI.Features.Room.Dtos;

public class RoomSimpleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

    public int MaxCapacity { get; set; }
    public int CurrentCapacity { get; set; }
}