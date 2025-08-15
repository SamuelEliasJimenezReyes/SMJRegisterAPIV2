using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPI.Entities.Enums;

public enum Conference
{
    [Description("Noreste")] 
    [Display(Name = "Noreste")]
    Noroeste=1,
    
    [Description("Sureste")] 
    [Display(Name = "Sureste")]
    Sureste,
    
    [Description("Central")] 
    [Display(Name = "Central")]
    Central,
    
    [Description("General")] 
    [Display(Name = "General")]
    General //SUPERADMIN
}