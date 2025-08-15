using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPIV2.Features.Camper.Queries.GetAll;
using SMJRegisterAPIV2.Features.Church.Dtos;
using SMJRegisterAPIV2.Features.Church.Queries.GetAll;
using SMJRegisterAPIV2.Features.Church.Queries.GetAllByConference;
using SMJRegisterAPIV2.Features.Church.Queries.GetById;

namespace SMJRegisterAPIV2.Features.Church.Endpoints;

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