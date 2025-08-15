using FluentValidation;

namespace SMJRegisterAPIV2.Features.Room.Command;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x=>x.Room.MaxCapacity)
            .GreaterThan(0)
            .WithMessage("Ingrese una Capacidad");
        
        RuleFor(x=>x.Room.Name)
            .NotEmpty().WithMessage("Ingrese un Nombre")
            .NotNull().WithMessage("Ingrese un Nombre");
    }
}