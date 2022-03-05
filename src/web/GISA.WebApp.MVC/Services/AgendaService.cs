using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public class AgendaService : Service, IAgendaService
    {
        private readonly HttpClient _httpClient;

        public AgendaService(HttpClient httpClient,
                             IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.PessoaUrl);

            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Atualizar(AgendaViewModel agendaViewModel)
        {
            var agendaContent = ObterConteudo(agendaViewModel);

            var response = await _httpClient.PutAsync("/api/agenda/editar", agendaContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<AgendaViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/agenda/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<AgendaViewModel>(response);
        }

        public async Task<IEnumerable<AgendaViewModel>> ObterAgendamentosPorPessoaId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/agenda/pessoa/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<AgendaViewModel>> (response);
        }

        public async Task<IEnumerable<AgendaViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/agenda/todos");

            TratarErrosResponse(response);
             
            return await DeserializarObjetoResponse<IEnumerable<AgendaViewModel>>(response);
        }

        public async Task<ResponseResult> Registrar(AgendaViewModel agendaViewModel)
        {
            var agendaContent = ObterConteudo(agendaViewModel);

            var response = await _httpClient.PostAsync("/api/agenda/novo", agendaContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
