using SMJRegisterAPI.Common.Entities;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public string? EvidenceURL { get; set; }
    public string? Coments { get; set; }
    //Relationships
    public int BanksInformationId { get; set; }
    public BanksInformation BanksInformation { get; set; }
    
    public int CamperId { get; set; }
    public Camper Camper { get; set; }
}