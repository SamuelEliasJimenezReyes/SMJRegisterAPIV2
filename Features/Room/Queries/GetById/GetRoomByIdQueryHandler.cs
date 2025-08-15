using AutoMapper;
using MediatR;
using SMJRegisterAPI.Features.Room.Dtos;
using SMJRegisterAPI.Features.Room.Repository;

namespace SMJRegisterAPI.Features.Room.Queries.GetById;

public class GetRoomByIdQueryHandler (IRoomRepository repository, IMapper mapper) 
    : IRequestHandler<GetRoomByIdQuery, RoomDto>
{
    public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdWithCamper(request.Id);
        return mapper.Map<RoomDto>(entity);
    }
}