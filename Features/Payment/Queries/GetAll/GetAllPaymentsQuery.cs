using MediatR;
using SMJRegisterAPI.Features.Payment.Dtos;

namespace SMJRegisterAPI.Features.Payment.Queries.GetAll;

public class GetAllPaymentsQuery : IRequest<IList<PaymentDto>>
{
    
}
