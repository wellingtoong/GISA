﻿using GISA.Convenio.API.Services.Consumer;
using GISA.Core.Utils;
using GISA.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GISA.Convenio.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroConvenioIntegration>()
                .AddHostedService<AtualizarConvenioIntegration>();
        }
    }
}