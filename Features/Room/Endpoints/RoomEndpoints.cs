using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPI.Features.Room.Command;
using SMJRegisterAPI.Features.Room.Command.AutomaticSorterByCamperId;
using SMJRegisterAPI.Features.Room.Command.AutomaticSorterByChurch;
using SMJRegisterAPI.Features.Room.Dtos;
using SMJRegisterAPI.Features.Room.Queries.GetAll;
using SMJRegisterAPI.Features.Room.Queries.GetById;

namespace SMJRegisterAPI.Features.Room.Endpoints;

public class RoomEndpoints() : CarterModule("/room")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAll);
        app.MapGet("/{id:int}", GetById).RequireAuthorization();
        app.MapPost("/", Create).RequireAuthorization();
        app.MapPost("/automatic-sorter-by-churchId/{ChurchId:int}", AutomaticSorterByChurchId)
            .RequireAuthorization();
        app.MapPost("/automatic-sorter-by-camperId/{CamperId:int}", AutomaticSorterByCamperId)
            .RequireAuthorization();
    }
    
    private async Task<Results<Ok<IList<RoomSimpleDto>>, NotFound>> GetAll(ISender sender)
    {
        var result = await sender.Send(new GetAllRoomsQuery());
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    private async Task<Results<Ok<RoomDto>, NotFound>> GetById(ISender sender, int id)
    {
        var result = await sender.Send(new GetRoomByIdQuery()
        {
            Id = id
        });
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    
    private async Task<Created> Create(ISender sender
        , CreateRoomDto dto)
    {
        var command = new CreateRoomCommand(dto);
        var result = await sender.Send(command);
        return TypedResults.Created();
    }

    private async Task<NoContent> AutomaticSorterByChurchId(ISender sender, int ChurchId)
    {
        var command = new AutomaticSorterByChurchCommand()
        {
            ChurchId = ChurchId
        };
        await sender.Send(command);
        return TypedResults.NoContent();
    }
    private async Task<NoContent> AutomaticSorterByCamperId(ISender sender, int CamperId)
    {
        var command = new AutomaticSorterByCamperIdCommand()
        {
            CamperId = CamperId
        };
        await sender.Send(command);
        return TypedResults.NoContent();
    }
}