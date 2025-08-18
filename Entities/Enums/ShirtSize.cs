using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPIV2.Entities.Enums;

public enum ShirtSize
{
    
    [Description("10")]
    [Display(Name = "10")]
    Diez = 1,
    
    [Description("12")]
    [Display(Name = "12")]
    Doce ,
    
    [Description("14")]
    [Display(Name = "14")]
    Catorce,
    
    [Description("16")]
    [Display(Name = "16")]
    dieciséis,
    
    [Description("XS - Extra Pequeño")]
    [Display(Name = "XS - Extra Pequeño")]
    XS ,
    
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