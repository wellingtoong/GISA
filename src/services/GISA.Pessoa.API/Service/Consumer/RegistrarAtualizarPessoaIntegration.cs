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
    public class RegistrarAtualizarPessoaIntegration : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistrarAtualizarPessoaIntegration(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<Domain.Pessoa, ResponseMessageDefault>(async request =>
                await ConsumerRegistrarAtualizarPessoa(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) => SetResponder();

        private async Task<ResponseMessageDefault> ConsumerRegistrarAtualizarPessoa(Domain.Pessoa pessoa)
        {
            bool sucesso = false;

            using (var scope = _serviceProvider.CreateScope())  
            {
                var _pessoaRepository = scope.ServiceProvider.GetRequiredService<IPessoaRepository>();

                if (pessoa.Id == null || pessoa.Id == Guid.Empty)
                {
                    try
                    {
                        sucesso = await _pessoaRepository.Adicionar(pessoa);
                    }
                    catch (Exception ex)
                    {
                        var test = ex.StackTrace;
                        var teste1 = ex.Message;
                    }                    
                }
                else
                {
                    sucesso = await _pessoaRepository.Atualizar(pessoa);
                }
            }

            return new ResponseMessageDefault() { Sucess = sucesso };
        }
    }
}
