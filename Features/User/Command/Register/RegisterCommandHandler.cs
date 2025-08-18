using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.User.Dtos;
using SMJRegisterAPIV2.Services.User;

namespace SMJRegisterAPIV2.Features.User.Command.Register;

public class RegisterCommandHandler( 
    UserManager<Entities.User> userManager,
    IJwtTokenService jwtTokenService,
    ApplicationDbContext context) : IRequestHandler<RegisterCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var strategy = context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

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

                await transaction.CommitAsync(cancellationToken);

                return new AuthResponseDto { Token = token, Expiration = DateTime.UtcNow.AddHours(2) };
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }

}