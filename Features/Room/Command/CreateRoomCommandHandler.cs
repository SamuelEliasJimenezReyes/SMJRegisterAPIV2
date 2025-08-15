using System.Runtime.Intrinsics.X86;
using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Room.Dtos;
using SMJRegisterAPI.Features.Room.Repository;

namespace SMJRegisterAPI.Features.Room.Command;

public class CreateRoomCommandHandler(IRoomRepository repository, IMapper mapper) : IRequestHandler<CreateRoomCommand, CreateRoomDto>
{
    public async Task<CreateRoomDto> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Entities.Room>(request.Room);
        await repository.AddAsync(entity);
        var dto = mapper.Map<CreateRoomDto>(entity);
        return dto;
    }
}