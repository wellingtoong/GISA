using GISA.WebApp.MVC.Extensions;
using GISA.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public class PessoaService : Service, IPessoaService
    {
        private readonly HttpClient _httpClient;

        public PessoaService(HttpClient httpClient,
                             IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.PessoaUrl);

            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Atualizar(PessoaViewModel pessoaViewModel)
        {
            var pessoaContent = ObterConteudo(pessoaViewModel);

            var response = await _httpClient.PutAsync("/api/pessoa/editar", pessoaContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<PessoaViewModel> ObterPorEmail(string email)
        {
            var response = await _httpClient.GetAsync($"/api/pessoa/{email}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PessoaViewModel>(response);
        }

        public async Task<PessoaViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/pessoa/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PessoaViewModel>(response);
        }

        public async Task<IEnumerable<PessoaViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/api/pessoa/todos");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<PessoaViewModel>>(response);
        }

        public async Task<int> ObterTotalUsuario()
        {
            var response = await _httpClient.GetAsync("/api/pessoa/total");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<int> ObterTotalUsuarioAtivo()
        {
            var response = await _httpClient.GetAsync("/api/pessoa/total-ativo");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<int> ObterTotalUsuarioInativo()
        {
            var response = await _httpClient.GetAsync("/api/pessoa/total-inativo");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<ResponseResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            var pessoaContent = ObterConteudo(pessoaViewModel);

            var response = await _httpClient.PostAsync("/api/pessoa/novo", pessoaContent);

            if (!TratarErrosResponse(response))
            {
                return await DeserializarObjetoResponse<ResponseResult>(response);
            }

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}