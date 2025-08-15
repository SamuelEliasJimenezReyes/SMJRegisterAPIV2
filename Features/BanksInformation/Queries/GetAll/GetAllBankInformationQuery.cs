using MediatR;
using SMJRegisterAPI.Features.BanksInformation.Dtos;

namespace SMJRegisterAPI.Features.BanksInformation.Queries.GetAll;

public class GetAllBankInformationQuery : IRequest<IList<BankInformationDto>>
{
    
}