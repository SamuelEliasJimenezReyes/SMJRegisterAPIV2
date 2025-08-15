using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPI.Entities.Enums;

public enum PayWay
{
    [Description("Pago Directo")] 
    [Display(Name = "Pago Directo")]
    DirectPayment = 1 ,
    
    [Description("Otros")] 
    [Display(Name = "Otros")]
    Other
}