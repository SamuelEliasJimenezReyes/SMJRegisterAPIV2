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
        var payment = mapper.Map<Entities.Payment>(request.Payment);
        
        payment.CamperId = request.Payment.CamperId;
        payment.BanksInformationId = request.Payment.BanksInformationId;
        payment.Amount = request.Payment.Amount;
        payment.Coments = request.Payment.Coments;
        var camper =await camperRepository.GetByIdAsync(request.Payment.CamperId);
        if (request.Payment.Evidence is not null)
        {
            var folderName = $"Camper-{camper.ID}-{camper.Name}-{camper.LastName}";
            var url = await fileStorage.Store("camper-documents",folderName,request.Payment.Evidence);
            payment.EvidenceURL = url;
        }
        await repository.AddAsync(payment);
        var Dto = mapper.Map<CreatePaymentDto>(payment);
        return Dto;
    }
}