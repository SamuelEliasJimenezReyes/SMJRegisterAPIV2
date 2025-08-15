using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Church.Dtos;
using SMJRegisterAPI.Features.Church.Repository;

namespace SMJRegisterAPI.Features.Church.Queries.GetById;

public class GetChurchByIdQueryHandler
    (IChurchRepository repository, IMapper mapper) : IRequestHandler<GetChurchByIdQuery, ChurchDTO>
{
    public async Task<ChurchDTO> Handle(GetChurchByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdWithCamper(request.Id);
        return mapper.Map<ChurchDTO>(entity);
    }
}