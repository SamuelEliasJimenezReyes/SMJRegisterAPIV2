using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Payment.Dtos;
using SMJRegisterAPIV2.Features.Payment.Repository;

namespace SMJRegisterAPIV2.Features.Payment.Queries.GetAll;

public class GetAllPaymentsQueryHandler(
    IPaymentRepository repository, 
    IMapper mapper) : IRequestHandler<GetAllPaymentsQuery, IList<PaymentDto>>
{
    public async Task<IList<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        var sortedList = list.OrderByDescending(x => x.ID);
        return mapper.Map<IList<PaymentDto>>(sortedList);
    }
}