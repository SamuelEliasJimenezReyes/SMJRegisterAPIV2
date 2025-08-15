using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Room.Dtos;
using SMJRegisterAPI.Features.Room.Repository;

namespace SMJRegisterAPI.Features.Room.Queries.GetAll;

public class GetAllRoomsQueryHandler(IRoomRepository repository, IMapper mapper) 
    : IRequestHandler<GetAllRoomsQuery, IList<RoomSimpleDto>>
{
    public async Task<IList<RoomSimpleDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await repository.GetAllAsync();
        return mapper.Map<IList<RoomSimpleDto>>(rooms);
    }
}