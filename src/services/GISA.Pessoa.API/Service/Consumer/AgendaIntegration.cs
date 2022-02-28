using GISA.Core.Communication;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service.Consumer
{
    public class AgendaIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public AgendaIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Agenda, ResponseResult>(async request =>
                await ConsumerAgenda(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseResult> ConsumerAgenda(Domain.Agenda agenda)
        {
            var response = new ResponseResult();

            using (var scope = _serviceProvider.CreateScope())  
            {
                bool result = false;
                var _agendaRepository = scope.ServiceProvider.GetRequiredService<IAgendaRepository>();

                if (agenda.Id == null || agenda.Id == Guid.Empty)
                {
                    result = await _agendaRepository.Adicionar(agenda);
                }
                else
                {
                    result = await _agendaRepository.Atualizar(agenda);
                }

                if (!result)
                {
                    response.Errors.Mensagens.Add("Ocorreu um erro interno ao inserir ou atualizar dados.");
                    return response;
                }
            }

            return new ResponseResult();
        }
    }
}
