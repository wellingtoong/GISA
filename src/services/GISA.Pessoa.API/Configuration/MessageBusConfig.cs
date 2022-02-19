using GISA.Pessoa.API.Service.Consumer;
using GISA.Core.Utils;
using GISA.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GISA.Pessoa.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistrarAtualizarPessoaIntegration>()
                .AddHostedService<RegistrarAtualizarPlanoIntegration>()
                .AddHostedService<RegistrarAtualizarAgendaIntegration>()
                .AddHostedService<RegistrarAtualizarPlanoClienteIntegration>();
        }
    }
}