using MediatR;
using SMJRegisterAPIV2.Features.User.Dtos;

namespace SMJRegisterAPIV2.Features.User.Command.Register;

public class RegisterCommand(RegisterRequestDto dto )  : IRequest<AuthResponseDto>
{
    public RegisterRequestDto RequestDto { get; set; } = dto;
}