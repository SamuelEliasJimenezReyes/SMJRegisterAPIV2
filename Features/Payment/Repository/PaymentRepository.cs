using SMJRegisterAPIV2.Database.Contexts;
using SMJRegisterAPIV2.Features.Common;

namespace SMJRegisterAPIV2.Features.Payment.Repository;

public class PaymentRepository(ApplicationDbContext context) : GenericRepository<Entities.Payment>(context) ,IPaymentRepository
{
    
}