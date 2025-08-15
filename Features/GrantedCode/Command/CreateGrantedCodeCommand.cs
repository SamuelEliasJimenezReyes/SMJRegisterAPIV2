using MediatR;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.GrantedCode.Dtos;

namespace SMJRegisterAPI.Features.GrantedCode.Command;

public class CreateGrantedCodeCommand(CreateGrantedCodeDTO grantedCode) : IRequest<CreateGrantedCodeDTO>
{
    public CreateGrantedCodeDTO GrantedCode { get; set; } = grantedCode;
}