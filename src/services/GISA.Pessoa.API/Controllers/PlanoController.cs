using AutoMapper;
using GISA.Core.Messages.Integration;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.Pessoa.API.Service;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Controllers
{
    [Route("api/plano")]
    public class PlanoController : MainController
    {
        private readonly IPlanoService _planoService;
        private readonly IPlanoRepository _planoRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;

        public PlanoController(IPlanoService planoService,
                               IPlanoRepository planoRepository,
                               IMapper mapper,
                               IMessageBus bus)
        {
            _planoService = planoService;
            _planoRepository = planoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("obter-planos")]
        public async Task<IActionResult> ObterTodos()
        {
            var pessoa = _mapper.Map<IEnumerable<PlanoViewModel>>(await _planoRepository.ObterTodos());

            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível listar os planos. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("obter-plano/{id:guid}")]
        public async Task<IActionResult> ObterPlanoPorId(Guid id)
        {
            var plano = _mapper.Map<PlanoViewModel>(await _planoRepository.ObterPorId(id));

            if (plano == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o plano. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(plano);
        }

        [HttpPut]
        [Route("atualizar-plano")]
        public async Task<IActionResult> Atualizar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _bus.RequestAsync<Domain.Plano, ResponseMessageDefault>(_mapper.Map<Domain.Plano>(planoViewModel));

            if (!result.Sucess)
            {
                AdicionarErroProcessamento("Não foi possível atualizar o plano. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(result);
        }

        [HttpPost]
        [Route("novo-registro")]
        public async Task<IActionResult> Registrar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _bus.RequestAsync<Domain.Plano, ResponseMessageDefault>(_mapper.Map<Domain.Plano>(planoViewModel));

            if (!result.Sucess)
            {
                AdicionarErroProcessamento("Não foi possível registrar o plano. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(result);
        }
    }
}
