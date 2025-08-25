using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SMJRegisterAPIV2.Features.Dashboard.Dtos;
using SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalByBank;
using SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalCamperByConference;
using SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalCash;

namespace SMJRegisterAPIV2.Features.Dashboard.Endpoints;

public class DashboardEndpoints () : CarterModule("/dashboard")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/banks", GetTotalByBank).RequireAuthorization();
        app.MapGet("/campers", GetCampersByConference).RequireAuthorization();
        app.MapGet("/cash", GetTotalCash).RequireAuthorization();
    }
    
    private async Task<Results<Ok<IList<GetTotalByBankDto>>, NotFound>> GetTotalByBank(ISender sender)
    {
        var result = await sender.Send(new GetTotalByBankQuery());
        return result == null || !result.Any() ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

    private async Task<Results<Ok<IList<GetCampersByConferenceDto>>, NotFound>> GetCampersByConference(ISender sender)
    {
        var result = await sender.Send(new GetCampersByConferenceQuery());
        return result == null || !result.Any() ? TypedResults.NotFound() : TypedResults.Ok(result);
    }

    private async Task<Results<Ok<GetTotalCashDto>, NotFound>> GetTotalCash(ISender sender)
    {
        var result = await sender.Send(new GetTotalCashQuery());
        return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
}