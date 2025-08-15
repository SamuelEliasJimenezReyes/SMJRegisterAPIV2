using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using SMJRegisterAPI.Entities.Enums;
using SMJRegisterAPI.Features.Camper.Dtos;
using SMJRegisterAPI.Features.Camper.Repository;
using SMJRegisterAPI.Features.GrantedCode.Repository;
using SMJRegisterAPI.Services.FileStore;
namespace SMJRegisterAPI.Features.Camper.Command.Create;

public class CreateCamperCommandHandler(ICamperRepository repository,
    IGrantedCodeRepository grantedCodeRepository, 
    IMapper mapper,
    IFileStorage storage)
    : IRequestHandler<CreateCamperCommand, CreateCamperDTO>
{

    public async Task<CreateCamperDTO> Handle(CreateCamperCommand request, CancellationToken cancellationToken)
    {
        var camper = mapper.Map<Entities.Camper>(request.Camper);
        
        camper.Gender = (Gender)request.Camper.Gender;
        camper.Condition = (Condition)request.Camper.Condition;
        camper.PayWay = (PayWay)request.Camper.PayType;
        camper.ShirtSize = (ShirtSize)request.Camper.ShirtSize;
        camper.ArrivedTimeSlot = (ArrivedTimeSlot)request.Camper.ArrivedTimeSlot;
        if(request.Camper.RoomId == 0)
                camper.RoomId = null;   

        var pricePerDay = 600m; 
        camper.TotalAmount = CalculateAmount(camper.ArrivedTimeSlot, pricePerDay);

        if (camper.IsGrant && request.Camper.GrantedAmount>0)
        {
            camper.TotalAmount = request.Camper.GrantedAmount;
            if (camper.TotalAmount < 0)
                camper.TotalAmount = 0;
        }
        await repository.AddAsync(camper);

        if (request.Camper.Documents.Any())
        {
            var folderName = $"Camper-{camper.ID}-{camper.Name}-{camper.LastName}";
            var urls = await storage.MultipleStore("camper-documents", folderName, request.Camper.Documents);
            camper.DocumentsURL = urls;
            camper.UpdatedAt = DateTime.Now;
            await repository.UpdateAsync(camper,camper.ID);
        }
        
        if (camper.IsGrant && !String.IsNullOrWhiteSpace(request.Camper.Code))
        {
            var grantedCode = await grantedCodeRepository.GetByCodeAsync(request.Camper.Code);
            grantedCode.IsUsed = true;
            grantedCode.CamperId = camper.ID;
            camper.GrantedCodeId = grantedCode.ID;
            await grantedCodeRepository.UpdateAsync(grantedCode, grantedCode.ID);
            camper.UpdatedAt = DateTime.Now;
            await repository.UpdateAsync(camper, camper.ID);
        }
        var Dto = mapper.Map<CreateCamperDTO>(camper);
        return Dto;
    }

    private decimal CalculateAmount(ArrivedTimeSlot arrivedTimeSlot, decimal pricePerDay)
    {
        return arrivedTimeSlot switch
        {
            ArrivedTimeSlot.SaturdayMorning => 4m * pricePerDay,
            ArrivedTimeSlot.SaturdayAfternoon => 3.5m * pricePerDay,
            ArrivedTimeSlot.Sunday => 3m * pricePerDay,
            ArrivedTimeSlot.Monday => 2m * pricePerDay,
            _ => 4m * pricePerDay
        };
    }
}