using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPI.Entities.Enums;

public enum Gender
{
    [Description("Hombre")] 
    [Display(Name = "Hombre")]
    Hombre = 1 ,
    
    [Description("Mujer")] 
    [Display(Name = "Mujer")]
    Mujer
}