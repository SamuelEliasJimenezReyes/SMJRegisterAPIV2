using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Church.Dtos;
using SMJRegisterAPI.Features.Church.Repository;

namespace SMJRegisterAPI.Features.Church.Queries.GetAll;

public class GetAllChurchQueryHandler(IChurchRepository repository, IMapper mapper) : IRequestHandler<GetAllChurchQuery, IList<ChurchSimpleDTO>>
{
    public async Task<IList<ChurchSimpleDTO>> Handle(GetAllChurchQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<IList<ChurchSimpleDTO>>(list);
    }
}