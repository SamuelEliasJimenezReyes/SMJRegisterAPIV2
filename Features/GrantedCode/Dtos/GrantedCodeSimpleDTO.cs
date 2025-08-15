using SMJRegisterAPI.Features.Camper.Dtos;

namespace SMJRegisterAPI.Features.GrantedCode.Dtos;

public class GrantedCodeSimpleDTO
{
    public string Code { get; set; }
    public decimal GrantAmount { get; set; }
    public bool IsUsed { get; set; } = false;
}