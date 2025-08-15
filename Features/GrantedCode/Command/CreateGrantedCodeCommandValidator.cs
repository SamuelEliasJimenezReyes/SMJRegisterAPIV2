using System.Security.Cryptography.Xml;
using FluentValidation;

namespace SMJRegisterAPI.Features.GrantedCode.Command;

public class CreateGrantedCodeCommandValidator : AbstractValidator<CreateGrantedCodeCommand>
{
    public CreateGrantedCodeCommandValidator()
    {
        RuleFor(x=>x.GrantedCode.GrantAmount)
            .GreaterThan(0)
            .WithMessage("La cantidad debe ser Mayor a 0");
    }
}