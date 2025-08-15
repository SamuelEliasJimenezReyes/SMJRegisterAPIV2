using SMJRegisterAPIV2.Common.Entities;
using SMJRegisterAPIV2.Entities.Enums;

namespace SMJRegisterAPIV2.Entities;

public class BanksInformation : BaseEntity
{
    public string AccountNumber { get; set; }    
    public Banks BankName { get; set; }    
    public Conference Conference { get; set; }    
    
    //relationships
    public ICollection<Payment> Payments { get; set; }
}