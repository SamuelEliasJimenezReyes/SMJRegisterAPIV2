using MediatR;
using SMJRegisterAPIV2.Features.Room.Dtos;

namespace SMJRegisterAPIV2.Features.Room.Queries.GetById;

public class GetRoomByIdQuery : IRequest<RoomDto>
{
    public int Id { get; set; }
}