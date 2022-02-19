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
    public class RegistrarAtualizarAgendaIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistrarAtualizarAgendaIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Agenda, ResponseMessageDefault>(async request =>
                await ConsumerRegistrarAtualizarAgenda(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseMessageDefault> ConsumerRegistrarAtualizarAgenda(Domain.Agenda agenda)
        {
            bool sucesso = false;

            using (var scope = _serviceProvider.CreateScope())  
            {
                var _agendaRepository = scope.ServiceProvider.GetRequiredService<IAgendaRepository>();

                if (agenda.Id == null || agenda.Id == Guid.Empty)
                {
                    sucesso = await _agendaRepository.Adicionar(agenda);
                }
                else
                {
                    sucesso = await _agendaRepository.Atualizar(agenda);
                }
            }

            return new ResponseMessageDefault() { Sucess = sucesso };
        }
    }
}
