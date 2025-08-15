using SMJRegisterAPI.Common.Entities;

namespace SMJRegisterAPI.Entities;

public class GrantedCode : BaseEntity
{
    public string Code { get; set; }
    public decimal GrantAmount { get; set; }
    public bool IsUsed { get; set; }
    
    //RelationShip
    public int? CamperId { get; set; }
    public Camper Camper { get; set; }
}