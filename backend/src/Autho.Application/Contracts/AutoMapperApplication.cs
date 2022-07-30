using Autho.Application.Contracts.Permission;
using Autho.Application.Contracts.Profile;
using Autho.Application.Contracts.User;
using Autho.Domain.Entities;
using AutoMapper;

namespace Autho.Application.Contracts
{
    public static class AutoMapperApplication
    {
        public static void RegisterMapping(IMapperConfigurationExpression map)
        {
            RegisterUserMapper(map);
            RegisterProfileMapper(map);
            RegisterPermissionMapper(map);
        }

        private static void RegisterUserMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<UserDomain, UserDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Email));
        }

        private static void RegisterProfileMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<ProfileDomain, ProfileDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Permissions, y => y.MapFrom(z => z.Permissions));
        }

        private static void RegisterPermissionMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<PermissionDomain, PermissionDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Code, y => y.MapFrom(z => z.Code));
        }
    }
}
