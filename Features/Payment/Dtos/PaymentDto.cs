using SMJRegisterAPIV2.Features.BanksInformation.Dtos;
using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.Payment.Dtos;

public class PaymentDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? EvidenceURL { get; set; }
    public string? Coments { get; set; }
    public bool IsCash { get; set; }
    public DateTime CreatedAt { get; set; }

    public BankInformationDto? BanksInformation { get; set; }
    
    public CamperSimpleDto Camper { get; set; }
}