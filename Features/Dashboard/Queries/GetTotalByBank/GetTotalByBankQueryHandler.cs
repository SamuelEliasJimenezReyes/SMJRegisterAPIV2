using MediatR;
using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Entities.Enums;
using SMJRegisterAPIV2.Features.Dashboard.Dtos;

namespace SMJRegisterAPIV2.Features.Dashboard.Queries.GetTotalByBank;

public class GetTotalByBankQueryHandler(ApplicationDbContext context) : IRequestHandler<GetTotalByBankQuery, IList<GetTotalByBankDto>>
{
    public async Task<IList<GetTotalByBankDto>> Handle(GetTotalByBankQuery request, CancellationToken cancellationToken)
    {
        var banks = Enum.GetValues(typeof(Banks)).Cast<Banks>();
        var bankTotals = await context.BanksInformations
            .Include(b=>b.Payments)
            .ToListAsync(cancellationToken);
        
        var result = banks.Select(bank =>
        {
            var total = bankTotals.Where(b=>b.BankName==bank)
                .SelectMany(b=>b.Payments)
                .Sum(p=>p.Amount);
            return new GetTotalByBankDto
            {
                BankName = bank.ToString(),
                TotalAmount = total
            };
        }).ToList();
        return result;
    }
}