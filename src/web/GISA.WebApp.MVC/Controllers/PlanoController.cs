using System;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class PlanoController : MainController
    {
        private readonly IPlanoService _planoService;

        public PlanoController(IPlanoService planoService) => _planoService = planoService;

        [HttpGet]
        [Route("plano")]
        public IActionResult Index() => View();

        [HttpGet]
        [Route("plano/todos")]
        public async Task<IActionResult> ObterTodos() => Json(await _planoService.ObterTodos());

        [HttpGet]
        [Route("plano/editar/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id) => View(await _planoService.ObterPorId(id));

        [HttpPost]
        [Route("plano/editar")]
        public async Task<IActionResult> Editar(Guid id, PlanoViewModel planoViewModel) => View(await _planoService.ObterPorId(id));

        [HttpGet]
        [Route("plano/novo")]
        public IActionResult Registrar()
        {
            ViewBag.ValidateForm = false;
            return View();
        }

        [HttpPost]
        [Route("plano/novo")]
        public async Task<IActionResult> Registrar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                return View(planoViewModel);
            }

            var result = await _planoService.Registrar(planoViewModel);
            return ResponsePossuiErros(result) ? View("Registrar") : RedirectToAction("Index", "Plano");
        }

        public async Task<IActionResult> Atualizar(Guid id, PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                return View("Editar", planoViewModel);
            }

            var result = await _planoService.Atualizar(planoViewModel);
            return ResponsePossuiErros(result) ? View("Editar") : RedirectToAction("Index", "Plano");
        }
    }
}
