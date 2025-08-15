using FluentValidation;
using SMJRegisterAPI.Features.GrantedCode.Repository;

namespace SMJRegisterAPI.Features.Camper.Command.Update;

public class UpdateCamperCommandValidator : AbstractValidator<UpdateCamperCommand>
{
    private readonly IServiceProvider _serviceProvider;
    public UpdateCamperCommandValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("El ID del camper debe ser válido");

        RuleFor(x => x.Camper.Name)
            .NotEmpty().WithMessage("El nombre no puede estar vacío")
            .NotNull().WithMessage("El nombre no puede estar vacío");

        RuleFor(x => x.Camper.LastName)
            .NotEmpty().WithMessage("El apellido no puede estar vacío")
            .NotNull().WithMessage("El apellido no puede estar vacío");

        RuleFor(x => x.Camper.Gender)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar un género válido");

        RuleFor(x => x.Camper.Condition)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar una condición válida");

        RuleFor(x => x.Camper.PayType)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar un tipo de pago válido");

        RuleFor(x => x.Camper.ShirtSize)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar una talla de camiseta válida");

        RuleFor(x => x.Camper.ChurchId)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar una iglesia válida");
    }
}