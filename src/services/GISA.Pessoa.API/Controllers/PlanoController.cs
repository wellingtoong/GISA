using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GISA.Core.Communication;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GISA.Pessoa.API.Controllers
{
    [Authorize]
    [Route("api")]
    public class PlanoController : MainController
    {
        private readonly IPlanoRepository _planoRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;

        public PlanoController(IPlanoRepository planoRepository, IMapper mapper, IMessageBus bus)
        {
            _planoRepository = planoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("plano/total")]
        public async Task<IActionResult> ObterTotalPlano()
        {
            var total = await _planoRepository.ObterTotalPlano();
            if (total == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o total plano. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(total);
        }

        [HttpGet]
        [Route("plano/total-ativo")]
        public async Task<IActionResult> ObterTotalPlanoAtivo()
        {
            var total = await _planoRepository.ObterTotalPlanoAtivo();
            if (total == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o total plano ativo. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(total);
        }

        [HttpGet]
        [Route("plano/total-inativo")]
        public async Task<IActionResult> ObterTotalPlanoInativo()
        {
            var total = await _planoRepository.ObterTotalPlanoInativo();
            if (total == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o total plano inativo. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(total);
        }

        [HttpGet]
        [Route("plano/todos")]
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
        [Route("plano/{id:guid}")]
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
        [Route("plano/editar")]
        public async Task<IActionResult> Atualizar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var result = await _bus.RequestAsync<Domain.Plano, ResponseResult>(_mapper.Map<Domain.Plano>(planoViewModel));

            return !OperacaoValida() ? CustomResponse(result) : (IActionResult)CustomResponse(result);
        }

        [HttpPost]
        [Route("plano/novo")]
        public async Task<IActionResult> Registrar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var result = await _bus.RequestAsync<Domain.Plano, ResponseResult>(_mapper.Map<Domain.Plano>(planoViewModel));

            return !OperacaoValida() ? CustomResponse(result) : (IActionResult)CustomResponse(result);
        }
    }
}
