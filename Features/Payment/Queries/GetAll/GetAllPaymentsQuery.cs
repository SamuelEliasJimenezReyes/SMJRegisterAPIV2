using MediatR;
using SMJRegisterAPIV2.Features.Payment.Dtos;

namespace SMJRegisterAPIV2.Features.Payment.Queries.GetAll;

public class GetAllPaymentsQuery : IRequest<IList<PaymentDto>>
{
    
}
