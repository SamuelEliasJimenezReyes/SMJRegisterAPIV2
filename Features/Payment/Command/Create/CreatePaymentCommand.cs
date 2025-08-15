using MediatR;
using SMJRegisterAPIV2.Features.Payment.Dtos;

namespace SMJRegisterAPIV2.Features.Payment.Command.Create;

public class CreatePaymentCommand(CreatePaymentDto payment) : IRequest<CreatePaymentDto>
{
    public CreatePaymentDto Payment { get; set; } = payment;
}