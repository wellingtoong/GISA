using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public class PlanoService : Service, IPlanoService
    {
        private readonly HttpClient _httpClient;

        public PlanoService(HttpClient httpClient,
                             IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.PlanoUrl);

            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Atualizar(PlanoViewModel planoViewModel)
        {
            var planoContent = ObterConteudo(planoViewModel);

            var response = await _httpClient.PutAsync("/api/plano/editar", planoContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<PlanoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/plano/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PlanoViewModel>(response);
        }

        public async Task<IEnumerable<PlanoViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/plano/todos");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<PlanoViewModel>>(response);
        }

        public async Task<int> ObterTotalPlano()
        {
            var response = await _httpClient.GetAsync("/api/plano/total");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<int> ObterTotalPlanoAtivo()
        {
            var response = await _httpClient.GetAsync("/api/plano/total-ativo");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<int> ObterTotalPlanoInativo()
        {
            var response = await _httpClient.GetAsync("/api/plano/total-inativo");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<ResponseResult> Registrar(PlanoViewModel planoViewModel)
        {
            var planoContent = ObterConteudo(planoViewModel);

            var response = await _httpClient.PostAsync("/api/plano/novo", planoContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
