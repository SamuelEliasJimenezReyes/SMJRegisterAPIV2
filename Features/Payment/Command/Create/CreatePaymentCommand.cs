using MediatR;
using SMJRegisterAPI.Features.Payment.Dtos;

namespace SMJRegisterAPI.Features.Payment.Command.Create;

public class CreatePaymentCommand(CreatePaymentDto payment) : IRequest<CreatePaymentDto>
{
    public CreatePaymentDto Payment { get; set; } = payment;
}