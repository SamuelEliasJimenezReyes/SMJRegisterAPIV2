using SMJRegisterAPI.Features.BanksInformation.Dtos;
using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.Payment.Dtos;

public class PaymentDto
{
    public decimal Amount { get; set; }
    public string? EvidenceURL { get; set; }
    public string? Coments { get; set; }
    
    public BankInformationDto BanksInformation { get; set; }
    
    public CamperSimpleDto Camper { get; set; }
}