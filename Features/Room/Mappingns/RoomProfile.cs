using AutoMapper;
using SMJRegisterAPI.Features.Room.Dtos;

namespace SMJRegisterAPI.Features.Room.Mappingns;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Entities.Room, RoomDto>();
        CreateMap<Entities.Room, RoomSimpleDto>();
    }
}