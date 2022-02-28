using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public class PlanoClienteService : Service, IPlanoClienteService
    {
        private readonly HttpClient _httpClient;

        public PlanoClienteService(HttpClient httpClient,
                             IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.PlanoClienteUrl);

            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Atualizar(PlanoClienteViewModel planoClienteViewModel)
        {
            var planoClient = ObterConteudo(planoClienteViewModel);

            var response = await _httpClient.PutAsync("/api/plano-cliente/atualizar-plano-cliente", planoClient);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<PlanoClienteViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/plano-cliente/obter-plano-cliente/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PlanoClienteViewModel>(response);
        }

        public async Task<PlanoClienteViewModel> ObterPorPessoaId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/plano-cliente/obter-plano-cliente-pessoa/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PlanoClienteViewModel>(response);
        }

        public async Task<IEnumerable<PlanoClienteViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/plano-cliente/obter-planos-clientes");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<PlanoClienteViewModel>>(response);
        }

        public async Task<ResponseResult> Registrar(PlanoClienteViewModel planoClienteViewModel)
        {
            var planoClient = ObterConteudo(planoClienteViewModel);

            var response = await _httpClient.PostAsync("/api/plano-cliente/novo-registro", planoClient);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
