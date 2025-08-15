using MediatR;
using Microsoft.AspNetCore.Identity;
using SMJRegisterAPI.Database.Contexts;
using SMJRegisterAPI.Features.User.Dtos;
using SMJRegisterAPI.Services.User;

namespace SMJRegisterAPI.Features.User.Command.Register;

public class RegisterCommandHandler( 
    UserManager<Entities.User> userManager,
    IJwtTokenService jwtTokenService,
    ApplicationDbContext context) : IRequestHandler<RegisterCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var req = request.RequestDto;
            var user = new Entities.User
            {
                Email = req.Email,
                UserName = $"{req.FirstName}{req.LastName}",
                Conference = (Entities.Enums.Conference)req.Conference,
            };
            var result = await userManager.CreateAsync(user, req.Passsword);
            if (!result.Succeeded)
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));
            var token = jwtTokenService.GenerateToken(user.Id, user.Email, user.Conference);
            await context.Database.CurrentTransaction.CommitAsync(cancellationToken);
            return new AuthResponseDto {Token = token, Expiration = DateTime.UtcNow.AddHours(2)};
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await context.Database.RollbackTransactionAsync(cancellationToken);
            throw;
        }
       
    }
}