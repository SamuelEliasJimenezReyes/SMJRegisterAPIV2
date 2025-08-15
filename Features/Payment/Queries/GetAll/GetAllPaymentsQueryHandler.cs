using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Payment.Dtos;
using SMJRegisterAPI.Features.Payment.Repository;

namespace SMJRegisterAPI.Features.Payment.Queries.GetAll;

public class GetAllPaymentsQueryHandler(
    IPaymentRepository repository, 
    IMapper mapper) : IRequestHandler<GetAllPaymentsQuery, IList<PaymentDto>>
{
    public async Task<IList<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<IList<PaymentDto>>(list);
    }
}