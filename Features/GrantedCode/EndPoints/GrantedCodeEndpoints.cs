using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPI.Features.GrantedCode.Command;
using SMJRegisterAPI.Features.GrantedCode.Dtos;
using SMJRegisterAPI.Features.GrantedCode.Queries.GetAll;

namespace SMJRegisterAPI.Features.GrantedCode.EndPoints;

public class GrantedCodeEndpoints() : CarterModule("/grantedCode")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/",GetAll).RequireAuthorization();
        app.MapPost("/", Create).RequireAuthorization();
    }
    private async Task<Results<Ok<IList<GrantedCodeDTO>>, NotFound>> GetAll(ISender sender)
    {
        var result = await sender.Send(new GetAllGrantedCodeQuery());
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    private async Task<Created> Create(ISender sender
        , CreateGrantedCodeDTO dto)
    {
        var command = new CreateGrantedCodeCommand(dto);
        var result = await sender.Send(command);
        return TypedResults.Created();
    }
}