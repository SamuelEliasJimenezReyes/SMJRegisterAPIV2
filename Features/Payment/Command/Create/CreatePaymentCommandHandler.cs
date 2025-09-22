using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Repository;
using SMJRegisterAPIV2.Features.Payment.Dtos;
using SMJRegisterAPIV2.Features.Payment.Repository;
using SMJRegisterAPIV2.Services.FileStore;

namespace SMJRegisterAPIV2.Features.Payment.Command.Create;

public class CreatePaymentCommandHandler(
    IPaymentRepository repository,
    ICamperRepository camperRepository,
    IMapper mapper,
    IFileStorage fileStorage
    ) : IRequestHandler<CreatePaymentCommand, CreatePaymentDto>
{
    public async Task<CreatePaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var camper = await camperRepository.GetByIdAsync(request.Payment.CamperId);
        
        var payment = mapper.Map<Entities.Payment>(request.Payment);

        payment.CamperId = request.Payment.CamperId;
        if (request.Payment.BanksInformationId == 0)
                payment.BanksInformationId = null;
        payment.Amount = request.Payment.Amount;
        payment.Coments = request.Payment.Coments;
        payment.IsCash = request.Payment.IsCash;

        if (request.Payment.Evidence is not null)
        {
            var folderName = $"Camper-{camper.ID}-{camper.Name}-{camper.LastName}";
            var url = await fileStorage.Store("camper-documents", folderName, request.Payment.Evidence);
            payment.EvidenceURL = url;
        }

        await repository.AddAsync(payment);

        camper.PaidAmount += payment.Amount;
        if (camper.PaidAmount >= camper.TotalAmount)
            camper.IsPaid = true;

        await camperRepository.UpdateAsync(camper,camper.ID);

        var dto = mapper.Map<CreatePaymentDto>(payment);
        return dto;
    }
}