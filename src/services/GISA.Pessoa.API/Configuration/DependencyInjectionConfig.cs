using GISA.Pessoa.API.Data;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GISA.Pessoa.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // repositorys
            services.AddScoped<ApplicationDbContext>();
            //services.AddScoped<IPessoaRepository, PessoaRepository>();

            // services
            services.AddScoped<IPessoaService, PessoaService>();

            return services;
        }
    }
}
