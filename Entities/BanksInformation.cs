using SMJRegisterAPI.Common.Entities;
using SMJRegisterAPI.Entities.Enums;

namespace SMJRegisterAPI.Entities;

public class BanksInformation : BaseEntity
{
    public string AccountNumber { get; set; }    
    public Banks BankName { get; set; }    
    public Conference Conference { get; set; }    
    
    //relationships
    public ICollection<Payment> Payments { get; set; }
}