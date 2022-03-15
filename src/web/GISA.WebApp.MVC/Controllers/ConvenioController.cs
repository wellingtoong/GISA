using System;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class ConvenioController : MainController
    {
        private readonly IConvenioService _convenioService;

        public ConvenioController(IConvenioService convenioService)
        {
            _convenioService = convenioService;
        }

        [HttpGet]
        [Route("convenio")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("convenio/todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _convenioService.ObterTodos());
        }

        [HttpGet]
        [Route("convenio/editar/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View("Editar");
            }

            var convenio = await _convenioService.ObterPorId(id);
            return View(convenio);
        }

        [HttpPost]
        [Route("convenio/editar")]
        public async Task<IActionResult> Editar(Guid id, ConvenioViewModel convenioViewModel)
        {
            var convenio = await _convenioService.ObterPorId(id);
            return View(convenio);
        }

        [HttpGet]
        [Route("convenio/novo")]
        public IActionResult Registrar()
        {
            ViewBag.ValidateForm = false;
            return View();
        }

        [HttpPost]
        [Route("convenio/novo")]
        public async Task<IActionResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View(convenioViewModel);
            }

            var result = await _convenioService.Registrar(convenioViewModel);

            return ResponsePossuiErros(result) ? View("Registrar") : (IActionResult)RedirectToAction("Index", "Convenio");
        }

        public async Task<IActionResult> Atualizar(Guid id, ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View("Editar", convenioViewModel);
            }

            var result = await _convenioService.Atualizar(convenioViewModel);

            return ResponsePossuiErros(result) ? View("Editar") : (IActionResult)RedirectToAction("Index", "Convenio");
        }
    }
}
