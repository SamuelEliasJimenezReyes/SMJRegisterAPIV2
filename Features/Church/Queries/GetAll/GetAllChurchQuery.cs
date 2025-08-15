using MediatR;
using SMJRegisterAPIV2.Features.Church.Dtos;

namespace SMJRegisterAPIV2.Features.Church.Queries.GetAll;

public class GetAllChurchQuery : IRequest<IList<ChurchSimpleDTO>>
{
    
}