using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SMJRegisterAPI.Features.Payment.Command.Create;
using SMJRegisterAPI.Features.Payment.Dtos;
using SMJRegisterAPI.Features.Payment.Queries.GetAll;

namespace SMJRegisterAPI.Features.Payment.Endpoints;

public class PaymentEndpoints() : CarterModule("/payments")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        this.RequireAuthorization();
        app.MapGet("/", GetAll);
        app.MapPost("/", Create)
            .Accepts<CreatePaymentDto>("multipart/form-data")
            .WithOpenApi()
            .DisableAntiforgery();
    }
    
    private async Task<Results<Ok<IList<PaymentDto>>, NotFound>> GetAll(ISender sender)
    {
        var result = await sender.Send(new GetAllPaymentsQuery());
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    private async Task<Created> Create(ISender sender
        ,[FromForm] CreatePaymentDto dto)
    {
        var command = new CreatePaymentCommand(dto);
        var result = await sender.Send(command);
        return TypedResults.Created();
    }

}