using Autho.Application.Interfaces;
using Autho.Application.Services;
using Autho.Domain.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application - Services
            services.AddScoped<IUserService, UserService>();

            // Infra - Data - Contexts
            services.AddScoped<IAuthoContext, AuthoContext>();
            services.AddScoped<AuthoContext>();

            // Infra - Data - Repositories
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
