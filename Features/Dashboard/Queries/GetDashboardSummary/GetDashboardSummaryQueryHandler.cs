using MediatR;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Dashboard.Dtos;

namespace SMJRegisterAPIV2.Features.Dashboard.Queries.GetDashboardSummary;

public class GetDashboardSummaryQueryHandler(ApplicationDbContext context) : IRequestHandler<GetDashboardSummaryQuery, DashboardSummaryDto>
{
    public async Task<DashboardSummaryDto> Handle(GetDashboardSummaryQuery request, CancellationToken cancellationToken)
    {
        var campers = await context.Campers.ToListAsync(cancellationToken);

        var totalCampersPaid = campers.Count(x => x.IsPaid);
        var totalAmountPaid = campers.Sum(c => c.PaidAmount);
        var totalAmountPending = campers.Sum(c => c.TotalAmount - c.PaidAmount);

        return new DashboardSummaryDto
        {
            TotalCampersPaid = totalCampersPaid,
            TotalAmountPaid = totalAmountPaid,
            TotalAmountPending = totalAmountPending
        };
    }
}