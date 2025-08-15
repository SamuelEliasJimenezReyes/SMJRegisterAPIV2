using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMJRegisterAPIV2.Entities.Enums;

public enum Banks
{
    [Description("Banco Popular")]
    [Display(Name = "Banco Popular")]
    Popular = 1,

    [Description("Banco BHD")]
    [Display(Name = "Banco BHD")]
    BHD,

    [Description("BanReservas")]
    [Display(Name = "BanReservas")]
    BanReservas,

    [Description("Banco Santa Cruz")]
    [Display(Name = "Banco Santa Cruz")]
    SantaCruz,

    [Description("Banco Caribe")]
    [Display(Name = "Banco Caribe")]
    Caribe,

    [Description("Banco López de Haro")]
    [Display(Name = "Banco López de Haro")]
    LopezDeHaro
}