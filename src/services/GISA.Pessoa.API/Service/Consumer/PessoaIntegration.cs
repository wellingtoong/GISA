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
    public class PessoaIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PessoaIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Pessoa, ResponseResult>(async request =>
                await ConsumerPessoa(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseResult> ConsumerPessoa(Domain.Pessoa pessoa)
        {
            var response = new ResponseResult();

            using (var scope = _serviceProvider.CreateScope())
            {
                bool result = false;
                var _pessoaRepository = scope.ServiceProvider.GetRequiredService<IPessoaRepository>();

                if (pessoa.Id == null || pessoa.Id == Guid.Empty)
                {
                    result = await _pessoaRepository.Adicionar(pessoa);
                }
                else
                {
                    result = await _pessoaRepository.Atualizar(pessoa);
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
