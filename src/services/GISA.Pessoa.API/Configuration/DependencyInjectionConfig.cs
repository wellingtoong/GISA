using Microsoft.Extensions.DependencyInjection;

namespace GISA.Pessoa.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
