using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.BanksInformation.Dtos;
using SMJRegisterAPI.Features.BanksInformation.Repository;

namespace SMJRegisterAPI.Features.BanksInformation.Queries.GetAllByConference;

public class GetAllByConferenceQueryHandler(
    IBankInformationRepository repository, 
    IMapper mapper)
    : IRequestHandler<GetAllByConferenceQuery, IList<BankInformationDto>>
{
    public async Task<IList<BankInformationDto>> Handle(GetAllByConferenceQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllBanksInformationByConference(request.Conference);
        return mapper.Map<List<BankInformationDto>>(list);
        
    }
}