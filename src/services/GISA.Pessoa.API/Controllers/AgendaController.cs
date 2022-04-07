using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GISA.Core.Communication;
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
    public class AgendaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;
        private readonly IAgendaRepository _agendaRepository;
        private readonly ILogger<AgendaController> _logger;

        public AgendaController(IAgendaRepository agendaRepository, IMapper mapper, IMessageBus bus, ILogger<AgendaController> logger)
        {
            _mapper = mapper;
            _agendaRepository = agendaRepository;
            _bus = bus;
            _logger = logger;
        }

        [HttpGet]
        [Route("agenda/todos")]
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
        [Route("agenda/{id:guid}")]
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

        [HttpGet]
        [Route("agenda/pessoa/{id:guid}")]
        public async Task<IActionResult> ObterAgendamentosPorPessoaId(Guid id)
        {
            var agenda = _mapper.Map<IEnumerable<AgendaViewModel>>(await _agendaRepository.ObterAgendamentosPorIdPessoa(id));

            if (agenda == null)
            {
                AdicionarErroProcessamento("Não foi possível obter a agenda. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(agenda);
        }

        [HttpPut]
        [Route("agenda/editar")]
        public async Task<IActionResult> Atualizar(Guid id, AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                LoggerRegister(ModelState);
                return CustomResponse(ModelState);
            }

            var result = await _bus.RequestAsync<Domain.Agenda, ResponseResult>(_mapper.Map<Domain.Agenda>(agendaViewModel));

            return !OperacaoValida() ? CustomResponse(result) : (IActionResult)CustomResponse(result);
        }

        [HttpPost]
        [Route("agenda/novo")]
        public async Task<IActionResult> Registrar(AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                LoggerRegister(ModelState);
                return CustomResponse(ModelState);
            }

            var result = await _bus.RequestAsync<Domain.Agenda, ResponseResult>(_mapper.Map<Domain.Agenda>(agendaViewModel));

            return !OperacaoValida() ? CustomResponse(result) : (IActionResult)CustomResponse(result);
        }

        private void LoggerRegister(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
                _logger.LogTrace(erro.ErrorMessage);
        }
    }
}
