using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Church.Dtos;
using SMJRegisterAPIV2.Features.Church.Repository;

namespace SMJRegisterAPIV2.Features.Church.Queries.GetById;

public class GetChurchByIdQueryHandler
    (IChurchRepository repository, IMapper mapper) : IRequestHandler<GetChurchByIdQuery, ChurchDTO>
{
    public async Task<ChurchDTO> Handle(GetChurchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdWithCamper(request.Id);
        return mapper.Map<ChurchDTO>(entity);
    }
}