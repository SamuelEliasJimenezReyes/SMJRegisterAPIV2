using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;
using SMJRegisterAPIV2.Features.BanksInformation.Repository;

namespace SMJRegisterAPIV2.Features.BanksInformation.Queries.GetAll;

public class GetAllBankInformationQueryHandler(IBankInformationRepository repository, IMapper mapper): IRequestHandler<GetAllBankInformationQuery,IList<BankInformationDto>>
{
    public async Task<IList<BankInformationDto>> Handle(GetAllBankInformationQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<List<BankInformationDto>>(list);
    }
}