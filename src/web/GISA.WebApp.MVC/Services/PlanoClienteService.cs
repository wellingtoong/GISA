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
            var planoClientContent = ObterConteudo(planoClienteViewModel);

            var response = await _httpClient.PutAsync("/api/plano-cliente/editar", planoClientContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<PlanoClienteViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/plano-cliente/editar/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PlanoClienteViewModel>(response);
        }

        public async Task<PlanoClienteViewModel> ObterPorPessoaId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/plano-cliente/pessoa/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PlanoClienteViewModel>(response);
        }

        public async Task<IEnumerable<PlanoClienteViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/plano-cliente/todos");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<PlanoClienteViewModel>>(response);
        }

        public async Task<ResponseResult> Registrar(PlanoClienteViewModel planoClienteViewModel)
        {
            var planoClientContent = ObterConteudo(planoClienteViewModel);

            var response = await _httpClient.PostAsync("/api/plano-cliente/novo", planoClientContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
