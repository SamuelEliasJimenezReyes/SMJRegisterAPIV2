using SMJRegisterAPI.Features.Church.Dtos;
using SMJRegisterAPI.Features.GrantedCode.Dtos;
using SMJRegisterAPI.Features.Room.Dtos;
namespace SMJRegisterAPI.Features.Camper.Dtos;

public class CamperDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string Coments { get; set; }
    public decimal  PaidAmount { get; set; }
    public bool IsGrant { get; set; } 
    public bool IsPaid { get; set; } 
    public string Gender { get; set; }
    public string Condition { get; set; }
    public string PayType { get; set; }
    public string ShirtSize { get; set; }
    public string ArrivedTimeSlot { get; set; }

    public List<string>? DocumentsURL { get; set; }

    
    public ChurchSimpleDTO Church { get; set; }
    public GrantedCodeSimpleDTO? GrantedCode { get; set; }
    public RoomSimpleDto? Room { get; set; }
}