using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPIV2.Entities.Enums;

public enum ArrivedTimeSlot
{
    [Description("Sabado Mañana")]
    [Display(Name = "Sabado Mañana")]
    SaturdayMorning = 1,
    [Description("Sabado Tarde")]
    [Display(Name = "Sabado Tarde")]
    SaturdayAfternoon = 2,
    [Description("Domingo")]
    [Display(Name = "Domingo")]
    Sunday,
    [Description("Lunes")]
    [Display(Name = "Lunes")]
    Monday
}