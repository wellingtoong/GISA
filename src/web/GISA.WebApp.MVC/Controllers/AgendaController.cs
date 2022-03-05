using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class AgendaController : MainController
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [Route("agenda")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("agenda/todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _agendaService.ObterTodos());
        }

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

            if (ResponsePossuiErros(result)) return View("Editar");

            return RedirectToAction("Index", "Agenda");
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

            if (ResponsePossuiErros(result)) return View("Editar");

            return View("Index");
        }
    }
}
