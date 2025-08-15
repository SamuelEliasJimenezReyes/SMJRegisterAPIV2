using MediatR;
using SMJRegisterAPI.Features.GrantedCode.Command;
using SMJRegisterAPI.Features.GrantedCode.Dtos;

namespace SMJRegisterAPI.Features.GrantedCode.Queries.GetAll;

public class GetAllGrantedCodeQuery : IRequest<IList<GrantedCodeDTO>>
{
    
}