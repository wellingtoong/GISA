using AutoMapper;
using GISA.Convenio.API.Data.Repository;
using GISA.Convenio.API.Models;
using GISA.Convenio.API.Service;
using GISA.Core.Communication;
using GISA.Core.DomainObjects;
using GISA.MessageBus;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Controllers
{
    [Authorize]
    [Route("api/convenio")]
    public class ConvenioController : MainController
    {
        private readonly IConvenioService _convenioService;
        private readonly IConvenioRepository _convenioRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;

        public ConvenioController(IConvenioService convenioService,
                                  IConvenioRepository convenioRepository,
                                  IMapper mapper,
                                  IMessageBus bus)
        {
            _convenioService = convenioService;
            _convenioRepository = convenioRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("total-convenio")]
        public async Task<IActionResult> ObterTotalConvenio()
        {
            var total = await _convenioRepository.ObterTotalConvenio();

            if (total == null)
            {
                AdicionarErroProcessamento("Não foi possível obter total de convenios. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(total);
        }

        [HttpGet]
        [Route("obter-convenios")]
        public async Task<IActionResult> ObterTodos()
        {
            var convenios = _mapper.Map<IEnumerable<ConvenioViewModel>>(await _convenioRepository.ObterTodosConvenioEndereco());

            if (convenios == null)
            {
                AdicionarErroProcessamento("Não foi possível listar os convenios. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(convenios);
        }

        [HttpGet]
        [Route("obter-convenio/{id:guid}")]
        public async Task<IActionResult> ObterConvenioPorId(Guid id)
        {
            var convenio = _mapper.Map<ConvenioViewModel>(await _convenioRepository.ObterConvenioEnderecoPorId(id));

            if (convenio == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o convenio. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(convenio);
        }

        [HttpPost]
        [Route("novo-registro")]
        public async Task<IActionResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(convenioViewModel.Email)) return CustomResponse();

            var result = await _bus.RequestAsync<Domain.Convenio, ResponseResult>(_mapper.Map<Domain.Convenio>(convenioViewModel));

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }

        [HttpPut]
        [Route("atualizar-convenio")]
        public async Task<IActionResult> Atualizar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(convenioViewModel.Email)) return CustomResponse();

            var result = await _bus.RequestAsync<Domain.Convenio, ResponseResult>(_mapper.Map<Domain.Convenio>(convenioViewModel));

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }

        [HttpPut]
        [Route("atualizar-convenio/{id:guid}/endereco")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var conveio = _mapper.Map<Domain.Convenio>(convenioViewModel);

            var result = await _convenioService.AtualizarEndereco(id, conveio);

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }

        private bool EmailValido(string email)
        {
            try
            {
                var result = new Email(email);
                if (!String.IsNullOrWhiteSpace(result.Endereco)) return true;
            }
            catch (DomainException)
            {
                AdicionarErroProcessamento("Endereço de e-mail inválido.");
                return false;
            }

            return false;
        }
    }
}