using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public class ConvenioService : Service, IConvenioService
    {
        private readonly HttpClient _httpClient;

        public ConvenioService(HttpClient httpClient,
                               IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.ConvenioUrl);

            _httpClient = httpClient;
        }

        public async Task<int> ObterTotalConvenio()
        {
            var response = await _httpClient.GetAsync("/api/convenio/total");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<ConvenioViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/convenio/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ConvenioViewModel>(response);
        }

        public async Task<IEnumerable<ConvenioViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/convenio/todos");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<ConvenioViewModel>>(response);
        }

        public async Task<ResponseResult> Atualizar(ConvenioViewModel convenioViewModel)
        {
            var convenioContent = ObterConteudo(convenioViewModel);

            var response = await _httpClient.PutAsync("/api/convenio/editar", convenioContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<ResponseResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            var convenioContent = ObterConteudo(convenioViewModel);

            var response = await _httpClient.PostAsync("/api/convenio/novo", convenioContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
