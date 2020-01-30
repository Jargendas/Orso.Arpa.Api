using AutoMapper;
using Orso.Arpa.Application.Dtos;
using Orso.Arpa.Domain.Logic.Auth;

namespace Orso.Arpa.Application.MappingProfiles
{
    public class SetRoleDtoMappingProfile : Profile
    {
        public SetRoleDtoMappingProfile()
        {
            CreateMap<SetRoleDto, SetRole.Command>();
        }
    }
}
