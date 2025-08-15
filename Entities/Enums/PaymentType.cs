using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPI.Entities.Enums;

public enum PaymentType
{
    [Description("Preinscripcion")] 
    [Display(Name = "Preinscripcion")]
    PreRegistration = 1 ,
    
    [Description("Pago Completo")] 
    [Display(Name = "Pago Completo")]
    FullPayment,
    
    [Description("Abono")] 
    [Display(Name = "Abono")]
    Installment,
    
    [Description("Otros")] 
    [Display(Name = "Otros")]
    Other
}