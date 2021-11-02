using GISA.Convenio.API.Data;
using GISA.Convenio.API.Data.Repository;
using GISA.Convenio.API.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GISA.Convenio.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // repositorys
            services.AddScoped<ConvenioDbContext>();
            services.AddScoped<IConvenioRepository, ConvenioRepository>();

            // services
            services.AddScoped<IConvenioService, ConvenioService>();

            return services;
        }
    }
}
