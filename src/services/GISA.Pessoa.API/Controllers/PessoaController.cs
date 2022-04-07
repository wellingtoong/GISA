using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GISA.Core.Communication;
using GISA.Core.DomainObjects;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace GISA.Pessoa.API.Controllers
{
    [Authorize]
    [Route("api")]
    public class PessoaController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(IPessoaRepository pessoaRepository, IMapper mapper, IMessageBus bus)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("pessoa/total")]
        public async Task<IActionResult> ObterTotalUsuario()
        {
            var pessoa = await _pessoaRepository.ObterTotalUsuario();
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obnter o total pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("pessoa/total-ativo")]
        public async Task<IActionResult> ObterTotalUsuarioAtivo()
        {
            var pessoa = await _pessoaRepository.ObterTotalUsuarioAtivo();
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obnter o total pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("pessoa/total-inativo")]
        public async Task<IActionResult> ObterTotalUsuarioInativo()
        {
            var pessoa = await _pessoaRepository.ObterTotalUsuarioInativo();
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obnter o total pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("pessoa/todos")]
        public async Task<IActionResult> ObterTodos()
        {
            var pessoa = _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterTodosComEndereco());
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível listar as pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("pessoa/{id:guid}")]
        public async Task<IActionResult> ObterPessoaPorId(Guid id)
        {
            var pessoa = _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPessoaComEndereco(id));
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obter a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("pessoa/{email}")]
        public async Task<IActionResult> ObterPessoaPorEmail(string email)
        {
            if (!EmailValido(email))
            {
                return CustomResponse();
            }

            var pessoa = _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPessoaPorEmail(email));
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obter a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpPut]
        [Route("pessoa/editar")]
        public async Task<IActionResult> Atualizar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                LoggerRegister(ModelState);
                return CustomResponse(ModelState);
            }

            if (!EmailValido(pessoaViewModel.Email))
            {
                return CustomResponse();
            }

            var result = await _bus.RequestAsync<Domain.Pessoa, ResponseResult>(_mapper.Map<Domain.Pessoa>(pessoaViewModel));

            return !OperacaoValida() ? CustomResponse(result) : (IActionResult)CustomResponse(result);
        }

        [HttpPost]
        [Route("pessoa/novo")]
        public async Task<IActionResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                LoggerRegister(ModelState);
                return CustomResponse(ModelState);
            }

            if (!EmailValido(pessoaViewModel.Email))
            {
                return CustomResponse();
            }

            var result = await _bus.RequestAsync<Domain.Pessoa, ResponseResult>(_mapper.Map<Domain.Pessoa>(pessoaViewModel));

            return !OperacaoValida() ? CustomResponse(result) : (IActionResult)CustomResponse(result);
        }

        private bool EmailValido(string email)
        {
            try
            {
                var result = new Email(email);
                if (!string.IsNullOrWhiteSpace(result.Endereco))
                {
                    return true;
                }
            }
            catch (DomainException)
            {
                AdicionarErroProcessamento("Endereço de e-mail inválido.");
                return false;
            }

            return false;
        }

        private void LoggerRegister(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
                _logger.LogTrace(erro.ErrorMessage);
        }
    }
}
