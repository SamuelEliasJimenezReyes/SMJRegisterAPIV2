using MediatR;
using SMJRegisterAPIV2.Features.Room.Dtos;

namespace SMJRegisterAPIV2.Features.Room.Queries.GetAll;

public class GetAllRoomsQuery : IRequest<IList<RoomSimpleDto>>
{
    
}