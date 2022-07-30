using Autho.Application.Contracts;
using Autho.Infra.Data.Repositories;

namespace Autho.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(map =>
            {
                AutoMapperRepository.RegisterMapping(map);
                AutoMapperApplication.RegisterMapping(map);
            });
        }
    }
}
