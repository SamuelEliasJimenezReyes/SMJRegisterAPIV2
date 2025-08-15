using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Church.Dtos;
using SMJRegisterAPIV2.Features.Church.Repository;

namespace SMJRegisterAPIV2.Features.Church.Queries.GetAllByConference;

public class GetAllChurchesByConferenceQueryHandler(IChurchRepository repository, IMapper mapper) : IRequestHandler<GetAllChurchesByConferenceQuery, IList<ChurchSimpleDTO>>
{
    public async Task<IList<ChurchSimpleDTO>> Handle(GetAllChurchesByConferenceQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetByConference(request.Conference);
        return mapper.Map<IList<ChurchSimpleDTO>>(list);
    }
}