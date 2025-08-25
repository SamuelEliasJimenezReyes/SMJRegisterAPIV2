using FluentValidation;
using SMJRegisterAPIV2.Features.Camper.Repository;

namespace SMJRegisterAPIV2.Features.Payment.Command.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    private readonly IServiceProvider _serviceProvider;

    public CreatePaymentCommandValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        RuleFor(x => x.Payment.Amount)
            .GreaterThan(0)
            .WithMessage("El monto debe ser mayor a 0.");

        RuleFor(x => x.Payment.CamperId)
            .MustAsync(async (camperId, cancellation) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var camperRepository = scope.ServiceProvider.GetRequiredService<ICamperRepository>();
                var camper = await camperRepository.GetByIdAsync(camperId);
                return camper != null;
            })
            .WithMessage("El campista no existe.");

        RuleFor(x => x)
            .MustAsync(async (command, cancellation) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var camperRepository = scope.ServiceProvider.GetRequiredService<ICamperRepository>();
                var camper = await camperRepository.GetByIdAsync(command.Payment.CamperId);

                if (camper == null) return true;

                var restante = camper.TotalAmount - camper.PaidAmount;
                return command.Payment.Amount <= restante;
            })
            .WithMessage("El monto del pago no puede ser mayor al restante que debe el campista.");
    }
}