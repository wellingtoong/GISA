using GISA.Pessoa.API.Data;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Service;
using GISA.WebApi.Core.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace GISA.Pessoa.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // repositorys
            services.AddScoped<PessoaDbContext>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IPlanoClienteRepository, PlanoClienteRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();

            // services
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IPlanoClienteService, PlanoClienteService>();
            services.AddScoped<IAgendaService, AgendaService>();
            //services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}
