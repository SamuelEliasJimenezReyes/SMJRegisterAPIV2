using MediatR;
using SMJRegisterAPI.Features.User.Dtos;

namespace SMJRegisterAPI.Features.User.Command.Register;

public class RegisterCommand(RegisterRequestDto dto )  : IRequest<AuthResponseDto>
{
    public RegisterRequestDto RequestDto { get; set; } = dto;
}