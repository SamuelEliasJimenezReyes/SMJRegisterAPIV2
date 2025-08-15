using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Camper.Dtos;
using SMJRegisterAPIV2.Features.Camper.Repository;
using SMJRegisterAPIV2.Features.GrantedCode.Repository;
using SMJRegisterAPIV2.Services.FileStore;

namespace SMJRegisterAPIV2.Features.Camper.Command.Update;

public class UpdateCamperCommandHandler(
    ICamperRepository repository,
    IGrantedCodeRepository grantedCodeRepository,
    IMapper mapper,
    IFileStorage storage)
    : IRequestHandler<UpdateCamperCommand, UpdateCamperDTO>
{
    public async Task<UpdateCamperDTO> Handle(UpdateCamperCommand request, CancellationToken cancellationToken)
    {
        var camper = await repository.GetByIdAsync(request.Id);

        camper.Name = request.Camper.Name;
        camper.LastName = request.Camper.LastName;
        camper.PaidAmount = request.Camper.PaidAmount;
        camper.IsGrant = request.Camper.IsGrant;
        camper.IsPaid = request.Camper.IsPaid;
        camper.Gender = (Entities.Enums.Gender)request.Camper.Gender;
        camper.Condition = (Entities.Enums.Condition)request.Camper.Condition;
        camper.PayWay = (Entities.Enums.PayWay)request.Camper.PayType;
        camper.ShirtSize = (Entities.Enums.ShirtSize)request.Camper.ShirtSize;
        camper.ChurchId = request.Camper.ChurchId;
        camper.RoomId = request.Camper.RoomId == 0 ? null : request.Camper.RoomId;

        camper.UpdatedAt = DateTime.Now;

        await repository.UpdateAsync(camper, camper.ID);

        var camperDto = mapper.Map<UpdateCamperDTO>(camper);
        return camperDto;
    }
}
