using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Room.Dtos;
using SMJRegisterAPIV2.Features.Room.Repository;

namespace SMJRegisterAPIV2.Features.Room.Queries.GetAll;

public class GetAllRoomsQueryHandler(IRoomRepository repository, IMapper mapper) 
    : IRequestHandler<GetAllRoomsQuery, IList<RoomSimpleDto>>
{
    public async Task<IList<RoomSimpleDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await repository.GetAllAsync();
        return mapper.Map<IList<RoomSimpleDto>>(rooms);
    }
}