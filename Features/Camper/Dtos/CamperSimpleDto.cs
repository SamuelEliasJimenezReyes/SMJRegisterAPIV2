using SMJRegisterAPIV2.Features.Church.Dtos;

namespace SMJRegisterAPIV2.Features.Camper.Dtos;

public class CamperSimpleDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsGrant { get; set; } 
    public string Gender { get; set; }
    public string Condition { get; set; }
    public string PayType { get; set; }
    public string ShirtSize { get; set; }
    public string ArrivedTimeSlot { get; set; }
    
    public ChurchSimpleDTO Church { get; set; }
}