using AutoMapper;
using GISA.Convenio.API.Data.Repository;
using GISA.Convenio.API.Models;
using GISA.Convenio.API.Service;
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

        public ConvenioController(IConvenioService convenioService,
                                  IConvenioRepository convenioRepository,
                                  IMapper mapper)
        {
            _convenioService = convenioService;
            _convenioRepository = convenioRepository;
            _mapper = mapper;
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
        [Route("atualizar-convenio/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var convenio = _mapper.Map<Domain.Convenio>(convenioViewModel);

            var result = await _convenioService.Atualizar(id, convenio);

            if (!result)
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
        [Route("registrar")]
        public async Task<IActionResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _convenioRepository.Adicionar(_mapper.Map<Domain.Convenio>(convenioViewModel));

            if (!result)
            {
                AdicionarErroProcessamento("Não foi possível registrar o convenio. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
        }
    }
}