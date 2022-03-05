using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Services;
using GISA.WebApp.MVC.Services.Handlers;
using GISA.WebApi.Core.Usuario;

namespace GISA.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            #region HttpServices
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddHttpClient<IPessoaService, PessoaService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IConvenioService, ConvenioService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IPlanoService, PlanoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IPlanoClienteService, PlanoClienteService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAgendaService, AgendaService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            #endregion
        }
    }
}