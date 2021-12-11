using System;
using System.Threading;
using System.Threading.Tasks;
using GISA.Convenio.API.Data.Repository;
using GISA.Core.Messages.Integration;
using GISA.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GISA.Convenio.API.Services.Consumer
{
    public class RegistroConvenioIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroConvenioIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Convenio, ResponseMessage>(async request =>
                await RegistrarCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseMessage> RegistrarCliente(Domain.Convenio convenio)
        {
            bool sucesso = false;

            using (var scope = _serviceProvider.CreateScope())
            {
                var _convenioRepository = scope.ServiceProvider.GetRequiredService<IConvenioRepository>();
                sucesso = await _convenioRepository.Adicionar(convenio);
            }

            return new ResponseMessage(sucesso);
        }
    }
}