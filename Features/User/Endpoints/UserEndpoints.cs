using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPI.Features.User.Command.Register;
using SMJRegisterAPI.Features.User.Dtos;
using SMJRegisterAPI.Features.User.Login;

namespace SMJRegisterAPI.Features.User.Endpoints;

public class UserEndpoints() : CarterModule("/user")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/register", Register);
        app.MapPost("/login", Login);
    }
    
    private async Task<Results<Ok<AuthResponseDto>, BadRequest<string>>> Register(
        ISender sender,
        RegisterRequestDto dto
    )
    {
        try
        {
            var command = new RegisterCommand(dto);
            var result = await sender.Send(command);
            return TypedResults.Ok(result);
        }
        catch (ApplicationException ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private async Task<Results<Ok<AuthResponseDto>, UnauthorizedHttpResult>> Login(
        ISender sender,
        LoginRequestDto dto
    )
    {
        try
        {
            var command = new LoginCommand(dto);
            var result = await sender.Send(command);
            return TypedResults.Ok(result);
        }
        catch (UnauthorizedAccessException)
        {
            return TypedResults.Unauthorized();
        }
    }
}