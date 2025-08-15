using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using SMJRegisterAPIV2.Features.User.Dtos;

namespace SMJRegisterAPIV2.Features.User.Login;

public class LoginCommand(LoginRequestDto dto)  : IRequest<AuthResponseDto>
{
    public LoginRequestDto RequestDto { get; set; } = dto;
}