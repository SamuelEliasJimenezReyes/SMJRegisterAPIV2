using MediatR;
using SMJRegisterAPI.Features.Room.Dtos;

namespace SMJRegisterAPI.Features.Room.Queries.GetById;

public class GetRoomByIdQuery : IRequest<RoomDto>
{
    public int Id { get; set; }
}