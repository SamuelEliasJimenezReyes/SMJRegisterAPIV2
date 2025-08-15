using SMJRegisterAPIV2.Common.Entities;

namespace SMJRegisterAPIV2.Entities;

public class GrantedCode : BaseEntity
{
    public string Code { get; set; }
    public decimal GrantAmount { get; set; }
    public bool IsUsed { get; set; }
    
    //RelationShip
    public int? CamperId { get; set; }
    public Camper Camper { get; set; }
}