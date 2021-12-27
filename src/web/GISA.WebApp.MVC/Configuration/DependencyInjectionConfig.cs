using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Services;
using GISA.WebApp.MVC.Services.Handlers;


namespace GISA.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddHttpClient<IConvenioService, ConvenioService>()
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}