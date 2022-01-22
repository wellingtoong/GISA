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
    public class RegistrarAtualizarPlanoIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistrarAtualizarPlanoIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Plano, ResponseMessageDefault>(async request =>
                await ConsumerRegistrarAtualizarPlano(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseMessageDefault> ConsumerRegistrarAtualizarPlano(Domain.Plano plano)
        {
            bool sucesso = false;

            using (var scope = _serviceProvider.CreateScope())  
            {
                var _planoRepository = scope.ServiceProvider.GetRequiredService<IPlanoRepository>();

                if (plano.Id == null || plano.Id == Guid.Empty)
                {
                    sucesso = await _planoRepository.Adicionar(plano);
                }
                else
                {
                    sucesso = await _planoRepository.Atualizar(plano);
                }
            }

            return new ResponseMessageDefault() { Sucess = sucesso };
        }
    }
}
