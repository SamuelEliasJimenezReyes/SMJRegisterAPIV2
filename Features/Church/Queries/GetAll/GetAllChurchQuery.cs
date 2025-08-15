using MediatR;
using SMJRegisterAPI.Features.Church.Dtos;

namespace SMJRegisterAPI.Features.Church.Queries.GetAll;

public class GetAllChurchQuery : IRequest<IList<ChurchSimpleDTO>>
{
    
}