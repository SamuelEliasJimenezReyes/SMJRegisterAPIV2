using MediatR;
using SMJRegisterAPI.Features.Room.Dtos;

namespace SMJRegisterAPI.Features.Room.Queries.GetAll;

public class GetAllRoomsQuery : IRequest<IList<RoomSimpleDto>>
{
    
}