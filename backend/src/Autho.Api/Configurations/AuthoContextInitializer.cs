using Autho.Infra.Data.Context;
using Autho.Infra.Data.Repositories;
using Autho.Infra.Data.Seed;
using AutoMapper;

namespace Autho.Api.Configurations
{
    public static class AuthoContextInitializer
    {
        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IAuthoContext>();
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                PermissionSeed.SeedData(new PermissionRepository(context, mapper));
                ProfileSeed.SeedData(new ProfileRepository(context, mapper), new PermissionRepository(context, mapper), mapper);
                //UserSeed.SeedData(new UserRepository(context, mapper), new ProfileRepository(context, mapper));
            }
        }
    }
}
