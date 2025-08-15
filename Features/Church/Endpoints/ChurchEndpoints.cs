using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPI.Features.Camper.Queries.GetAll;
using SMJRegisterAPI.Features.Church.Dtos;
using SMJRegisterAPI.Features.Church.Queries.GetAll;
using SMJRegisterAPI.Features.Church.Queries.GetAllByConference;
using SMJRegisterAPI.Features.Church.Queries.GetById;

namespace SMJRegisterAPI.Features.Church.Endpoints;

public class ChurchEndpoints() : CarterModule("/church")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/",GetAll);
        app.MapGet("/{id:int}",GetById).RequireAuthorization();
        app.MapGet("/get-by-conference/{conference:int}",GetAllByConference);
    }
    
    private async Task<Results<Ok<IList<ChurchSimpleDTO>>, NotFound>> GetAll(ISender sender)
    {
        var result = await sender.Send(new GetAllChurchQuery());
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    private async Task<Results<Ok<ChurchDTO>, NotFound>> GetById(ISender sender, int id)
    {
        var result = await sender.Send(new GetChurchByIdQuery()
        {
            Id = id
        });
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    
    private async Task<Results<Ok<IList<ChurchSimpleDTO>>, NotFound>> GetAllByConference(ISender sender, int conference)
    {
        var result = await sender.Send(new GetAllChurchesByConferenceQuery
        {
            Conference = conference
        });
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
}