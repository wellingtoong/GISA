using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class PlanoClienteController : MainController
    {
        private readonly IPlanoClienteService _planoClienteService;

        public PlanoClienteController(IPlanoClienteService planoClienteService)
        {
            _planoClienteService = planoClienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("plano-cliente/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _planoClienteService.ObterTodos());
        }

        [Route("plano-cliente/obter-plano/{id:guid}")]
        public async Task<IActionResult> ObterPlanoClientePorPessoaId(Guid id)
        {
            var planoCliente = await _planoClienteService.ObterPorPessoaId(id);
            return Ok(planoCliente);
        }

        [HttpPost]
        [Route("plano-cliente/editar-plano")]
        public async Task<IActionResult> Editar(Guid id, PlanoClienteViewModel planoClienteViewModel)
        {
            var planoCliente = await _planoClienteService.ObterPorId(id);
            return View(planoCliente);
        }

        [Route("plano-cliente/novo-plano")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [Route("plano-cliente/novo-plano")]
        public async Task<IActionResult> Registrar(PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return View(planoClienteViewModel);

            var result = await _planoClienteService.Registrar(planoClienteViewModel);

            if (!result.Sucess)
            {
                // TODO: faço algo
            }

            return Ok(result);
        }

        public async Task<IActionResult> Atualizar(Guid id, PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return View(planoClienteViewModel);

            var result = await _planoClienteService.Atualizar(planoClienteViewModel);

            if (!result.Sucess)
            {
                // TODO: faço algo
            }

            return View("Index");
        }
    }
}
