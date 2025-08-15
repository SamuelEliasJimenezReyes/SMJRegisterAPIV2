using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.GrantedCode.Dtos;
using SMJRegisterAPIV2.Features.GrantedCode.Repository;
using SMJRegisterAPIV2.Services.CodeGenerator;

namespace SMJRegisterAPIV2.Features.GrantedCode.Command;

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