using System;
using System.Threading;
using System.Threading.Tasks;
using GISA.Pessoa.API.Data.Repository;
using GISA.Core.Messages.Integration;
using GISA.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GISA.Pessoa.API.Service.Consumer
{
    public class RegistrarAtualizarPlanoClienteIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistrarAtualizarPlanoClienteIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.PlanoCliente, ResponseMessageDefault>(async request =>
                await ConsumerRegistrarAtualizarPlanoCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseMessageDefault> ConsumerRegistrarAtualizarPlanoCliente(Domain.PlanoCliente planoCliente)
        {
            bool sucesso = false;

            using (var scope = _serviceProvider.CreateScope())  
            {
                var _planoRepository = scope.ServiceProvider.GetRequiredService<IPlanoClienteRepository>();

                if (planoCliente.Id == null || planoCliente.Id == Guid.Empty)
                {
                    sucesso = await _planoRepository.Adicionar(planoCliente);
                }
                else
                {
                    sucesso = await _planoRepository.Atualizar(planoCliente);
                }
            }

            return new ResponseMessageDefault() { Sucess = sucesso };
        }
    }
}
