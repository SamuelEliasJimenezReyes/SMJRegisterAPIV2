namespace SMJRegisterAPI.Features.GrantedCode.Dtos;

public class CreateGrantedCodeDTO 
{
    public decimal GrantAmount { get; set; }
    public bool IsUsed { get; set; }
}