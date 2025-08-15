using SMJRegisterAPI.Database.Contexts;
using SMJRegisterAPI.Features.Common;

namespace SMJRegisterAPI.Features.Payment.Repository;

public class PaymentRepository(ApplicationDbContext context) : GenericRepository<Entities.Payment>(context) ,IPaymentRepository
{
    
}