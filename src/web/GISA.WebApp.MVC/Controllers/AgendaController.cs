using System;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class AgendaController : MainController
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService) => _agendaService = agendaService;

        [HttpGet]
        [Route("agenda")]
        public IActionResult Index() => View();

        [HttpGet]
        [Route("agenda/todos")]
        public async Task<IActionResult> ObterTodos() => Json(await _agendaService.ObterTodos());

        [HttpGet]
        [Route("agenda/agendamentos/{id:guid}")]
        public async Task<IActionResult> ObterAgendamentosPorPessoaId(Guid id) => Json(await _agendaService.ObterAgendamentosPorPessoaId(id));

        [HttpGet]
        [Route("agenda/editar/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var agenda = await _agendaService.ObterPorId(id);
            return View(agenda);
        }

        [HttpPost]
        [Route("agenda/editar")]
        public async Task<IActionResult> Editar(Guid id, AgendaViewModel agendaViewModel)
        {
            var agenda = await _agendaService.ObterPorId(id);
            return View(agenda);
        }

        [HttpGet]
        [Route("agenda/novo")]
        public IActionResult Registrar()
        {
            ViewBag.ValidateForm = false;
            return View();
        }

        [HttpPost]
        [Route("agenda/novo")]
        public async Task<IActionResult> Registrar(AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View(agendaViewModel);
            }

            var result = await _agendaService.Registrar(agendaViewModel);
            return ResponsePossuiErros(result) ? View("Editar") : (IActionResult)RedirectToAction("Index", "Agenda");
        }

        public async Task<IActionResult> Atualizar(Guid id, AgendaViewModel agendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View("Editar", agendaViewModel);
            }

            var result = await _agendaService.Atualizar(agendaViewModel);
            return ResponsePossuiErros(result) ? View("Editar") : (IActionResult)View("Index");
        }

        [HttpGet]
        [Route("agenda/minha-agenda")]
        public IActionResult MinhaAgenda() => View();
    }
}
