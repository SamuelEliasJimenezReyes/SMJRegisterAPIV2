using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.GrantedCode.Dtos;
using SMJRegisterAPI.Features.GrantedCode.Repository;

namespace SMJRegisterAPI.Features.GrantedCode.Queries.GetAll;

public class GetAllGrantedCodeQueryHandler (IGrantedCodeRepository repository, IMapper mapper)
    : IRequestHandler<GetAllGrantedCodeQuery, IList<GrantedCodeDTO>>
{
    public async Task<IList<GrantedCodeDTO>> Handle(GetAllGrantedCodeQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<IList<GrantedCodeDTO>>(list);
    }
}