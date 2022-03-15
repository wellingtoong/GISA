using System;
using System.Threading;
using System.Threading.Tasks;
using GISA.Convenio.API.Data.Repository;
using GISA.Core.Communication;
using GISA.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GISA.Convenio.API.Services.Consumer
{
    public class ConvenioIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public ConvenioIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Convenio, ResponseResult>(async request =>
                await ConsumerConvenio(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseResult> ConsumerConvenio(Domain.Convenio convenio)
        {
            var response = new ResponseResult();

            using (var scope = _serviceProvider.CreateScope())
            {
                var result = false;
                var _convenioRepository = scope.ServiceProvider.GetRequiredService<IConvenioRepository>();

                if (convenio.Id == null || convenio.Id == Guid.Empty)
                {
                    result = await _convenioRepository.Adicionar(convenio);
                }
                else
                {
                    result = await _convenioRepository.Atualizar(convenio);
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