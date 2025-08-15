using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.BanksInformation.Dtos;
using SMJRegisterAPI.Features.BanksInformation.Repository;

namespace SMJRegisterAPI.Features.BanksInformation.Queries.GetAll;

public class GetAllBankInformationQueryHandler(IBankInformationRepository repository, IMapper mapper): IRequestHandler<GetAllBankInformationQuery,IList<BankInformationDto>>
{
    public async Task<IList<BankInformationDto>> Handle(GetAllBankInformationQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<List<BankInformationDto>>(list);
    }
}