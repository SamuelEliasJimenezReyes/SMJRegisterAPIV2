using SMJRegisterAPIV2.Features.Church.Dtos;
using SMJRegisterAPIV2.Features.GrantedCode.Dtos;
using SMJRegisterAPIV2.Features.Room.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Dtos;

public class CamperDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string Coments { get; set; }
    public decimal  PaidAmount { get; set; }
    public decimal  TotalAmount { get; set; }
    public bool IsGrant { get; set; } 
    public bool IsPaid { get; set; } 
    public string Gender { get; set; }
    public string Condition { get; set; }
    public string PayType { get; set; }
    public string ShirtSize { get; set; }
    public string ArrivedTimeSlot { get; set; }

    public string? DocumentsURL { get; set; }

    
    public ChurchSimpleDTO Church { get; set; }
    public GrantedCodeSimpleDTO? GrantedCode { get; set; }
    public RoomSimpleDto? Room { get; set; }
}