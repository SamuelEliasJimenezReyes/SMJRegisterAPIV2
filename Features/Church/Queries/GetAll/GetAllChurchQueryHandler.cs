using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Church.Dtos;
using SMJRegisterAPIV2.Features.Church.Repository;

namespace SMJRegisterAPIV2.Features.Church.Queries.GetAll;

public class GetAllChurchQueryHandler(IChurchRepository repository, IMapper mapper) : IRequestHandler<GetAllChurchQuery, IList<ChurchSimpleDTO>>
{
    public async Task<IList<ChurchSimpleDTO>> Handle(GetAllChurchQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<IList<ChurchSimpleDTO>>(list);
    }
}