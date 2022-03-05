using AutoMapper;
using GISA.Core.Communication;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.Pessoa.API.Service;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Controllers
{
    [Authorize]
    [Route("api/agenda")]
    public class AgendaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;
        private readonly IAgendaRepository _agendaRepository;

        public AgendaController(IAgendaService agendaService,
                                IAgendaRepository agendaRepository,
                                IMapper mapper,
                                IMessageBus bus)
        {
            _mapper = mapper;
            _agendaRepository = agendaRepository;
            _bus = bus;
        }

        [HttpGet]
        [Route("obter-agendas")]
        public async Task<IActionResult> ObterTodos() 
        {
            var agendas = _mapper.Map<IEnumerable<AgendaViewModel>>(await _agendaRepository.ObterTodos());

            if (agendas == null)
            {
                AdicionarErroProcessamento("Não foi possível listar os agendamentos. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(agendas);
        }

        [HttpGet]
        [Route("obter-agenda/{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var agenda = _mapper.Map<AgendaViewModel>(await _agendaRepository.ObterPorId(id));

            if (agenda == null)
            {
                AdicionarErroProcessamento("Não foi possível obter a agenda. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(agenda);
        }

        [HttpPut]
        [Route("atualizar-agenda")]
        public async Task<IActionResult> Atualizar(Guid id, AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _bus.RequestAsync<Domain.Agenda, ResponseResult>(_mapper.Map<Domain.Agenda>(agendaViewModel));

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }
                             
        [HttpPost]
        [Route("novo-registro")]
        public async Task<IActionResult> Registrar(AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _bus.RequestAsync<Domain.Agenda, ResponseResult>(_mapper.Map<Domain.Agenda>(agendaViewModel));

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }
    }
}
