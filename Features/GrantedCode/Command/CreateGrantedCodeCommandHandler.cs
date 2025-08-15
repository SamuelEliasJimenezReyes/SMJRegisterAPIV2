using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.GrantedCode.Dtos;
using SMJRegisterAPI.Features.GrantedCode.Repository;
using SMJRegisterAPI.Services.CodeGenerator;

namespace SMJRegisterAPI.Features.GrantedCode.Command;

public class CreateGrantedCodeCommandHandler(IGrantedCodeRepository repository,
    IMapper mapper ,
    IGenerateCodeService codeService) : IRequestHandler<CreateGrantedCodeCommand, CreateGrantedCodeDTO> 
{
    public async Task<CreateGrantedCodeDTO> Handle(CreateGrantedCodeCommand request, CancellationToken cancellationToken)
    {
        var grantedCode =  mapper.Map<Entities.GrantedCode>(request.GrantedCode);
        grantedCode.Code = codeService.GenerateAlphanumericCode();
        grantedCode.IsUsed = false;
        await repository.AddAsync(grantedCode);
        var Dto = mapper.Map<CreateGrantedCodeDTO>(grantedCode);
        return Dto;
    }
}