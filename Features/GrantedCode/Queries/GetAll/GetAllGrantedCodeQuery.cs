using MediatR;
using SMJRegisterAPIV2.Features.GrantedCode.Command;
using SMJRegisterAPIV2.Features.GrantedCode.Dtos;

namespace SMJRegisterAPIV2.Features.GrantedCode.Queries.GetAll;

public class GetAllGrantedCodeQuery : IRequest<IList<GrantedCodeDTO>>
{
    
}