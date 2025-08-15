using System.Globalization;
using AutoMapper;
using Humanizer;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Queries.GetById;

public class GetCamperByIdQueryHandler(ICamperRepository repository, IMapper mapper)
    : IRequestHandler<GetCamperByIdQuery, CamperDTO>
{

    public async Task<CamperDTO> Handle(GetCamperByIdQuery request, CancellationToken cancellationToken)
    {
        var entityDb = await repository.GetByIdAsync(request.ID);
        var mapped = mapper.Map<CamperDTO>(entityDb);
        return mapped;
    }
}