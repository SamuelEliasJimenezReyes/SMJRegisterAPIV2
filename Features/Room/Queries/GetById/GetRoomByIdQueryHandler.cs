using AutoMapper;
using MediatR;
using SMJRegisterAPIV2.Features.Room.Dtos;
using SMJRegisterAPIV2.Features.Room.Repository;

namespace SMJRegisterAPIV2.Features.Room.Queries.GetById;

public class GetRoomByIdQueryHandler (IRoomRepository repository, IMapper mapper) 
    : IRequestHandler<GetRoomByIdQuery, RoomDto>
{
    public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdWithCamper(request.Id);
        return mapper.Map<RoomDto>(entity);
    }
}