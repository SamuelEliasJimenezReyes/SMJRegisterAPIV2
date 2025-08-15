using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.BanksInformation.Dtos;
using SMJRegisterAPIV2.Features.BanksInformation.Repository;

namespace SMJRegisterAPIV2.Features.BanksInformation.Queries.GetAllByConference;

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