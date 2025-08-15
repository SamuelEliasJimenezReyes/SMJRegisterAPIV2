using MediatR;
using SMJRegisterAPI.Features.Room.Dtos;

namespace SMJRegisterAPI.Features.Room.Command;

public class CreateRoomCommand(CreateRoomDto room) : IRequest<CreateRoomDto>
{
    public CreateRoomDto Room { get; set; } = room;
}