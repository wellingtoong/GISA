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
    public class PlanoIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PlanoIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Plano, ResponseResult>(async request =>
                await ConsumerPlano(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseResult> ConsumerPlano(Domain.Plano plano)
        {
            var response = new ResponseResult();

            using (var scope = _serviceProvider.CreateScope())  
            {
                bool result = false;
                var _planoRepository = scope.ServiceProvider.GetRequiredService<IPlanoRepository>();

                if (plano.Id == null || plano.Id == Guid.Empty)
                {
                    result = await _planoRepository.Adicionar(plano);
                }
                else
                {
                    result = await _planoRepository.Atualizar(plano);
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