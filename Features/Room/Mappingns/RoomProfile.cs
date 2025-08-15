using AutoMapper;
using SMJRegisterAPIV2.Features.Room.Dtos;

namespace SMJRegisterAPIV2.Features.Room.Mappingns;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Entities.Room, RoomDto>();
        CreateMap<Entities.Room, RoomSimpleDto>();
    }
}