using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using SMJRegisterAPI.Features.User.Dtos;

namespace SMJRegisterAPI.Features.User.Login;

public class LoginCommand(LoginRequestDto dto)  : IRequest<AuthResponseDto>
{
    public LoginRequestDto RequestDto { get; set; } = dto;
}