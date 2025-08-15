using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.GrantedCode.Dtos;

namespace SMJRegisterAPIV2.Features.GrantedCode.Command;

public class CreateGrantedCodeCommand(CreateGrantedCodeDTO grantedCode) : IRequest<CreateGrantedCodeDTO>
{
    public CreateGrantedCodeDTO GrantedCode { get; set; } = grantedCode;
}