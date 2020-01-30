using AutoMapper;
using Orso.Arpa.Application.Dtos;
using Orso.Arpa.Domain.Logic.Appointments;

namespace Orso.Arpa.Application.MappingProfiles
{
    public class RemoveRoomDtoMappingProfile : Profile
    {
        public RemoveRoomDtoMappingProfile()
        {
            CreateMap<RemoveRoomDto, RemoveRoom.Command>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId));
        }
    }
}
