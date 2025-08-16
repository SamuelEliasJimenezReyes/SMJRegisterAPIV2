using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;
using SMJRegisterAPIV2.Features.BanksInformation.Queries.GetAll;
using SMJRegisterAPIV2.Features.BanksInformation.Queries.GetAllByConference;

namespace SMJRegisterAPIV2.Features.BanksInformation.Endpoints;

public class BankInformationEndpoints() : CarterModule("/bank-information")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllBankInformation).RequireAuthorization();
        app.MapGet("/get-by-conference/{conference:int}", GetAllByConference);
    }
    private async Task<Results<Ok<IList<BankInformationDto>>, NotFound>> GetAllBankInformation(ISender sender)
    {
        var result = await sender.Send(new GetAllBankInformationQuery());
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
    private async Task<Results<Ok<IList<BankInformationDto>>, NotFound>> GetAllByConference(ISender sender, int conference)
    {
        var result = await sender.Send(new GetAllByConferenceQuery()
        {
            Conference = conference
        });
        return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
}