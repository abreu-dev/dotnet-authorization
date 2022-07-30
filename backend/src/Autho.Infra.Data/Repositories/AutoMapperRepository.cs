using Autho.Domain.Entities;
using Autho.Infra.Data.Entities;
using AutoMapper;

namespace Autho.Infra.Data.Repositories
{
    public static class AutoMapperRepository
    {
        public static void RegisterMapping(IMapperConfigurationExpression map)
        {
            RegisterPermissionMapper(map);
            RegisterProfileMapper(map);
            RegisterProfilePermissionMapper(map);
            RegisterUserMapper(map);
            RegisterUserProfileMapper(map);
        }

        private static void RegisterPermissionMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<PermissionDomain, PermissionData>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Code, y => y.MapFrom(z => z.Code));

            map.CreateMap<PermissionData, PermissionDomain>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Code, y => y.MapFrom(z => z.Code));
        }

        private static void RegisterProfileMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<ProfileDomain, ProfileData>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Permissions, y => y.MapFrom(z => z.Permissions));

            map.CreateMap<ProfileData, ProfileDomain>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Permissions, y => y.MapFrom(z => z.Permissions));
        }

        private static void RegisterProfilePermissionMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<PermissionDomain, ProfilePermissionData>()
                .ForMember(x => x.PermissionId, y => y.MapFrom(z => z.Id));

            map.CreateMap<ProfilePermissionData, PermissionDomain>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Permission.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Permission.Name))
                .ForMember(x => x.Code, y => y.MapFrom(z => z.Permission.Code));
        }

        private static void RegisterUserMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<UserDomain, UserData>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Profiles, y => y.MapFrom(z => z.Profiles));

            map.CreateMap<UserData, UserDomain>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Profiles, y => y.MapFrom(z => z.Profiles));
        }

        private static void RegisterUserProfileMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<ProfileDomain, UserProfileData>()
                .ForMember(x => x.ProfileId, y => y.MapFrom(z => z.Id));

            map.CreateMap<UserProfileData, ProfileDomain>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Profile.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Profile.Name))
                .ForMember(x => x.Permissions, y => y.MapFrom(z => z.Profile.Permissions));
        }
    }
}
