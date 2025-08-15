using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.GrantedCode.Dtos;
using SMJRegisterAPIV2.Features.GrantedCode.Repository;

namespace SMJRegisterAPIV2.Features.GrantedCode.Queries.GetAll;

public class GetAllGrantedCodeQueryHandler (IGrantedCodeRepository repository, IMapper mapper)
    : IRequestHandler<GetAllGrantedCodeQuery, IList<GrantedCodeDTO>>
{
    public async Task<IList<GrantedCodeDTO>> Handle(GetAllGrantedCodeQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync();
        return mapper.Map<IList<GrantedCodeDTO>>(list);
    }
}