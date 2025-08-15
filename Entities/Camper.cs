using SMJRegisterAPIV2.Common.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Entities;

public class Camper : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string? Coments { get; set; }
    public List<string>? DocumentsURL { get; set; }
    public decimal  PaidAmount { get; set; }
    public decimal  TotalAmount { get; set; }
    public bool IsGrant { get; set; } = false;
    public bool IsPaid { get; set; } = false;
    public Gender Gender { get; set; }
    public Condition Condition { get; set; }
    public PayWay PayWay { get; set; }
    public ShirtSize ShirtSize { get; set; }
    public ArrivedTimeSlot ArrivedTimeSlot { get; set; }

    //RelationsShip
    public int ChurchId { get; set; }
    public Church Church { get; set; }
    
    public int? RoomId { get; set; }
    public Room Room { get; set; }
    
    public int? GrantedCodeId { get; set; }
    public GrantedCode GrantedCode { get; set; }           

    public ICollection<Payment> Payments  { get; set; }
}