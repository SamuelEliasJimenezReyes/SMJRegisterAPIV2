using MediatR;
using SMJRegisterAPIV2.Features.Room.Dtos;

namespace SMJRegisterAPIV2.Features.Room.Command;

public class CreateRoomCommand(CreateRoomDto room) : IRequest<CreateRoomDto>
{
    public CreateRoomDto Room { get; set; } = room;
}