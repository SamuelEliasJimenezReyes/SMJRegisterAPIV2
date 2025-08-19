using FluentValidation;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;
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
            .Must(phone => string.IsNullOrWhiteSpace(phone) || phone.All(char.IsDigit))
            .WithMessage("El número de teléfono solo puede contener números.")
            .MustAsync(async (phoneNumber, cancellationToken) =>
            {
                var digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

                using var scope = _serviceProvider.CreateScope();
                var camperRepository = scope.ServiceProvider.GetRequiredService<ICamperRepository>();
                var exists = await camperRepository.ExistByPhoneNumber(digitsOnly);
                return !exists;
            })
            .WithMessage("El número de teléfono ya está registrado.");


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

        RuleFor(x => x.Camper.Document)
            .NotEmpty().WithMessage("Debe de subir un comprobante")
            .Must(file => file is not null && file.Length > 0)
            .WithMessage("El archivo '{PropertyName}' no puede estar vacío")
            .Must(file => file is null || file.Length <= 2 * 1024 * 1024) // 2 MB en bytes
            .WithMessage("El archivo '{PropertyName}' no puede exceder 2 MB")
            .Must(file =>
            {
                if (file is null) return true;
                var validExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(file.FileName).ToLower();
                return validExtensions.Contains(extension);
            })
            .WithMessage("El archivo debe ser una imagen válida (.jpg, .jpeg, .png)");

            
    }
}