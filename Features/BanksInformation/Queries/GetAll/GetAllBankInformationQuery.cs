using MediatR;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;

namespace SMJRegisterAPIV2.Features.BanksInformation.Queries.GetAll;

public class GetAllBankInformationQuery : IRequest<IList<BankInformationDto>>
{
    
}