using AutoMapper;
using GISA.Convenio.API.Data.Repository;
using GISA.Convenio.API.Models;
using GISA.Convenio.API.Service;
using GISA.Core.DomainObjects;
using GISA.Core.Messages.Integration;
using GISA.MessageBus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Controllers
{
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

        [HttpPut]
        [Route("atualizar-convenio")]
        public async Task<IActionResult> Atualizar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(convenioViewModel.Email)) return CustomResponse();

            var result = 
                await _bus.RequestAsync<Domain.Convenio, ResponseMessage>(_mapper.Map<Domain.Convenio>(convenioViewModel));

            if (!result.Sucesso)
            {
                AdicionarErroProcessamento("Não foi possível atualizar o convenio. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
        }

        [HttpPut]
        [Route("atualizar-convenio/{id:guid}/endereco")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var conveio = _mapper.Map<Domain.Convenio>(convenioViewModel);

            var result = await _convenioService.AtualizarEndereco(id, conveio);

            if (!result)
            {
                AdicionarErroProcessamento("Não foi possível atualizar o endereço do convenio. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
        }

        [HttpPost]
        [Route("novo-registro")]
        public async Task<IActionResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(convenioViewModel.Email)) return CustomResponse();

            var result = await _bus.RequestAsync<Domain.Convenio, ResponseMessage>(_mapper.Map<Domain.Convenio>(convenioViewModel));

            if (!result.Sucesso)
            {
                AdicionarErroProcessamento("Não foi possível registrar o convenio. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
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