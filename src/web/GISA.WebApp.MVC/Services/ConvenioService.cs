using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
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
            httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);

            _httpClient = httpClient;
        }

        public async Task<ResponseMessage> Atualizar(ConvenioViewModel convenioViewModel)
        {
            var atualizarConvenio = ObterConteudo(convenioViewModel);

            var response = await _httpClient.PostAsync("/api/convenio/atualizar-convenio", atualizarConvenio);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseMessage>(response);
            }

            return await DeserializarObjetoResponse<ResponseMessage>(response);
        }

        public async Task<ResponseMessage> Registrar(ConvenioViewModel convenioViewModel)
        {
            var registroConvenio = ObterConteudo(convenioViewModel);

            var response = await _httpClient.PostAsync("/api/convenio/novo-registro", registroConvenio);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseMessage>(response);
            }

            return await DeserializarObjetoResponse<ResponseMessage>(response);
        }
    }
}
