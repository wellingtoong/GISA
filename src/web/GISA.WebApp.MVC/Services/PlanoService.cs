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

        public async Task<ResponseMessageDefault> Atualizar(PlanoViewModel planoViewModel)
        {
            var planoContent = ObterConteudo(planoViewModel);

            var response = await _httpClient.PutAsync("/api/plano/atualizar-plano", planoContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseMessageDefault>(response);
            }

            return await DeserializarObjetoResponse<ResponseMessageDefault>(response);
        }

        public async Task<PlanoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/plano/obter-plano/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PlanoViewModel>(response);
        }

        public async Task<IEnumerable<PlanoViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/plano/obter-pessoas");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<PlanoViewModel>>(response);
        }

        public async Task<ResponseMessageDefault> Registrar(PlanoViewModel planoViewModel)
        {
            var planoContent = ObterConteudo(planoViewModel);

            var response = await _httpClient.PostAsync("/api/plano/novo-registro", planoContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseMessageDefault>(response);
            }

            return await DeserializarObjetoResponse<ResponseMessageDefault>(response);
        }
    }
}
