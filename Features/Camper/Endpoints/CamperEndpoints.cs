using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SMJRegisterAPIV2.Features.Camper.Command.Create;
using SMJRegisterAPIV2.Features.Camper.Command.Update;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Queries.GetAll;
using SMJRegisterAPIV2.Features.Camper.Queries.GetAllByChurchID;
using SMJRegisterAPIV2.Features.Camper.Queries.GetAllByConference;
using SMJRegisterAPIV2.Features.Camper.Queries.GetByAllCondition;
using SMJRegisterAPIV2.Features.Camper.Queries.GetById;

namespace SMJRegisterAPIV2.Features.Camper.Endpoints;

public class CamperEndpoints() : CarterModule("/camper")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllCampers).RequireAuthorization();
        app.MapGet("/{id:int}", GetCamperById).RequireAuthorization();
        app.MapPost("/", CreateCamper)
            .Accepts<CreateCamperDTO>("multipart/form-data") 
            .DisableAntiforgery();
        app.MapGet("/get-by-condition{condition:int}", GetAllByCondition).RequireAuthorization();
        app.MapGet("/get-by-church/{churchId:int}", GetAllByChurchId).RequireAuthorization();
        app.MapGet("/get-by-conference/{conference:int}", GetAllByConference).RequireAuthorization();
        app.MapPut("/{id:int}", UpdateCamper).RequireAuthorization();
    }

    
    private async Task<Results<Ok<IList<CamperSimpleDto>>, NotFound>> GetAllCampers(ISender sender)
    {
        var result = await sender.Send(new GetAllCampersQuery());
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

    private async Task<Results<Ok<CamperDTO>, NotFound>> GetCamperById(ISender sender, int id)
    {
        var result = await sender.Send(new GetCamperByIdQuery
        {
            ID = id
        });

        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

    private async Task<Created> CreateCamper(ISender sender
        ,[FromForm] CreateCamperDTO dto)
    {
        var command = new CreateCamperCommand(dto);
        var result = await sender.Send(command);
        return TypedResults.Created();
    }

    private async Task<Results<Ok<List<CamperDTO>>, NotFound>> GetAllByCondition(ISender sender, int condition)
    {
        var result = await sender.Send(new GetAllCamperByConditionQuery()
        {
            Condition = condition
        });
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

    private async Task<Results<Ok<List<CamperDTO>>, NotFound>> GetAllByChurchId(ISender sender, int churchId)
    {
        var result = await sender.Send(new GetAllCampersByChurchIdQuery()
        {
            ChurchId = churchId
        });
        return  result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

    private async Task<Results<Ok<List<CamperDTO>>, NotFound>> GetAllByConference(ISender sender, int conference)
    {
        var result = await sender.Send(new GetAllCamperByConferenceQuery
        {
            Conference = conference
        });
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    private async Task<Results<Ok<UpdateCamperDTO>, NotFound>> UpdateCamper(ISender sender, int id, UpdateCamperDTO dto)
    {
        var command = new UpdateCamperCommand( dto, id);
        var result = await sender.Send(command);
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

}