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

        [HttpGet("obter-todos")]
        public async Task<IEnumerable<ConvenioViewModel>> ObterTodos()
        {
            var convenios = await _convenioService.ObterTodos();
            return _mapper.Map<IEnumerable<ConvenioViewModel>>(convenios);
        }

        [HttpPost("novo-convenio")]
        public async Task<ActionResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var convenio = _mapper.Map<Domain.Convenio>(convenioViewModel);
            return Ok(await _convenioRepository.Adicionar(convenio));
        }

        private async Task<ConvenioViewModel> ObterConvenio(Guid id) 
        {
            var convenio = _mapper.Map<ConvenioViewModel>(await _convenioRepository.ObterConvenioEndereco(id));
            return convenio;
        }
    }
}
