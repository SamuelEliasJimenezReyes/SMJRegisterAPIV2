using SMJRegisterAPIV2.Features.Camper.Dtos;

namespace SMJRegisterAPIV2.Features.GrantedCode.Dtos;

public class GrantedCodeSimpleDTO
{
    public string Code { get; set; }
    public decimal GrantAmount { get; set; }
    public bool IsUsed { get; set; } = false;
}