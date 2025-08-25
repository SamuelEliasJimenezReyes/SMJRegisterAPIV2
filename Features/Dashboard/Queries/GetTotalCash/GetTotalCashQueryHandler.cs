using MediatR;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Dashboard.Dtos;

namespace SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalCash;

public class GetTotalCashQueryHandler(ApplicationDbContext context) : IRequestHandler<GetTotalCashQuery, GetTotalCashDto>
{
    public async Task<GetTotalCashDto> Handle(GetTotalCashQuery request, CancellationToken cancellationToken)
    {
        var totalCash = await context.Payments.Where(p=>p.IsCash ==true )
            .SumAsync(p=>p.Amount, cancellationToken: cancellationToken);
        
        return new GetTotalCashDto { TotalCash = totalCash };
    }
}