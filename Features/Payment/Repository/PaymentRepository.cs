using Microsoft.EntityFrameworkCore;
using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Payment.Repository;

public class PaymentRepository(ApplicationDbContext context) : GenericRepository<Entities.Payment>(context) ,IPaymentRepository
{
    public override async Task<List<Entities.Payment>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        return await context.Payments.
            Include(x=>x.Camper)
            .Include(x=>x.BanksInformation)
            .ToListAsync();
    }
}