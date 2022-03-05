using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class PlanoClienteController : MainController
    {
        private readonly IPlanoClienteService _planoClienteService;

        public PlanoClienteController(IPlanoClienteService planoClienteService)
        {
            _planoClienteService = planoClienteService;
        }

        [HttpGet]
        [Route("plano-cliente")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("plano-cliente/todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _planoClienteService.ObterTodos());
        }

        [HttpGet]
        [Route("plano-cliente/{id:guid}")]
        public async Task<IActionResult> ObterPlanoClientePorPessoaId(Guid id)
        {
            var planoCliente = await _planoClienteService.ObterPorPessoaId(id);
            return Ok(planoCliente);
        }

        [HttpGet]
        [Route("plano-cliente/editar")]
        public async Task<IActionResult> Editar(Guid id, PlanoClienteViewModel planoClienteViewModel)
        {
            var planoCliente = await _planoClienteService.ObterPorId(id);
            return View(planoCliente);
        }

        [HttpGet]
        [Route("plano-cliente/novo")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [Route("plano-cliente/novo")]
        public async Task<IActionResult> Registrar(PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return View(planoClienteViewModel);

            var result = await _planoClienteService.Registrar(planoClienteViewModel);

            if (ResponsePossuiErros(result)) return View("Registrar");

            return Ok(result);
        }

        public async Task<IActionResult> Atualizar(Guid id, PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return View(planoClienteViewModel);

            var result = await _planoClienteService.Atualizar(planoClienteViewModel);

            if (ResponsePossuiErros(result)) return View("Editar");

            return RedirectToAction("Index", "PlanoCliente");
        }
    }
}
