using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPI.Entities.Enums;

public enum ShirtSize
{
    [Description("XS - Extra Pequeño")]
    [Display(Name = "XS - Extra Pequeño")]
    XS = 1,
    
    [Description("S - Pequeño")]
    [Display(Name = "S - Pequeño")]
    S,
    
    [Description("M - Mediano")]
    [Display(Name = "M - Mediano")]
    M,
    
    [Description("L - Grande")]
    [Display(Name = "L - Grande")]
    L,
    
    [Description("XL - Extra Grande")]
    [Display(Name = "XL - Extra Grande")]
    XL,
    
    [Description("XXL - Doble Extra Grande")]
    [Display(Name = "XXL - Doble Extra Grande")]
    XXL,
    
    [Description("XXXL - Triple Extra Grande")]
    [Display(Name = "XXXL - Triple Extra Grande")]
    XXXL
}