using System;
using System.Threading;
using System.Threading.Tasks;
using GISA.Core.Communication;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GISA.Pessoa.API.Service.Consumer
{
    public class PlanoClienteIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PlanoClienteIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.PlanoCliente, ResponseResult>(async request =>
                await ConsumerPlanoCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseResult> ConsumerPlanoCliente(Domain.PlanoCliente planoCliente)
        {
            var response = new ResponseResult();

            using (var scope = _serviceProvider.CreateScope())
            {
                bool result = false;
                var _planoRepository = scope.ServiceProvider.GetRequiredService<IPlanoClienteRepository>();

                if (planoCliente.Id == null || planoCliente.Id == Guid.Empty)
                {
                    result = await _planoRepository.Adicionar(planoCliente);
                }
                else
                {
                    result = await _planoRepository.Atualizar(planoCliente);
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
