using FluentValidation;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.GrantedCode.Repository;

namespace SMJRegisterAPIV2.Features.Camper.Command.Create;

public class CreateCamperCommandValidator : AbstractValidator<CreateCamperCommand>
{
    private readonly IServiceProvider _serviceProvider;

    public CreateCamperCommandValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        RuleFor(x => x.Camper.PhoneNumber)
            .NotEmpty().WithMessage("El número de teléfono es obligatorio.")
            .Matches(@"^[^a-zA-Z]*$").WithMessage("El número de teléfono no debe contener letras.");

        RuleFor(x => x.Camper.Name)
            .NotEmpty().WithMessage("El Nombre de no puede estar vacio")
            .NotNull().WithMessage("El nombre no puede estar vacio");

        RuleFor(x => x.Camper.LastName)
            .NotEmpty().WithMessage("El apellido no puede estar vacio")
            .NotNull().WithMessage("El apellido no puede estar vacio");
        
        RuleFor(x => x.Camper.Gender)
            .GreaterThan(0)
            .WithMessage("El genero no puede estar vacio");
        
        RuleFor(x => x.Camper.Code)
            .NotEmpty().WithMessage("El codigo no puede estar vacio")
            .NotNull().WithMessage("Necesita colocar un codigo")
            .MustAsync(async (code, cancellationToken) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var grantedCodeRepository = scope.ServiceProvider.GetRequiredService<IGrantedCodeRepository>();
                var exists = await grantedCodeRepository.ExistCodeAsync(code);
                return exists;
            }).WithMessage("El Codigo no existe")
            .MustAsync(async (code, cancellationToken) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var grantedCodeRepository = scope.ServiceProvider.GetRequiredService<IGrantedCodeRepository>();
                var isUsed = await grantedCodeRepository.CodeIsUsedAsync(code);
                return !isUsed;
            }).WithMessage("El Codigo ya ha sido usado")
            .When(x => x.Camper.IsGrant == true);
    }
}