using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Church.Dtos;
using SMJRegisterAPI.Features.Church.Repository;

namespace SMJRegisterAPI.Features.Church.Queries.GetAllByConference;

public class GetAllChurchesByConferenceQueryHandler(IChurchRepository repository, IMapper mapper) : IRequestHandler<GetAllChurchesByConferenceQuery, IList<ChurchSimpleDTO>>
{
    public async Task<IList<ChurchSimpleDTO>> Handle(GetAllChurchesByConferenceQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetByConference(request.Conference);
        return mapper.Map<IList<ChurchSimpleDTO>>(list);
    }
}