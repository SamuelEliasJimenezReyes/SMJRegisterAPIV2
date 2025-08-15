using MediatR;
using Microsoft.AspNetCore.Identity;
using SMJRegisterAPIV2.Features.User.Dtos;
using SMJRegisterAPIV2.Services.User;

namespace SMJRegisterAPIV2.Features.User.Login;

public class LoginCommandHandler( SignInManager<Entities.User> signInManager ,
    UserManager<Entities.User> userManager,
    IJwtTokenService jwtTokenService) : IRequestHandler<LoginCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var req= request.RequestDto;
        var user = await userManager.FindByEmailAsync(req.Email);

        var result = await signInManager.CheckPasswordSignInAsync(user, req.Password, false);

        var token = jwtTokenService.GenerateToken(user.Id, user.Email, user.Conference);
        return new AuthResponseDto { Token = token , Expiration = DateTime.Now.AddHours(2)};
    }
}