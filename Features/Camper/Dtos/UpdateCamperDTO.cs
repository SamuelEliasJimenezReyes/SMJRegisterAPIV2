namespace SMJRegisterAPIV2.Features.Camper.Dtos;

public class UpdateCamperDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public decimal PaidAmount { get; set; }
    public bool IsGrant { get; set; }
    public bool IsPaid { get; set; }
    public int Gender { get; set; }
    public int Condition { get; set; }
    public int PayType { get; set; }
    public int ShirtSize { get; set; }

    public int ChurchId { get; set; }
    public int? RoomId { get; set; }
}