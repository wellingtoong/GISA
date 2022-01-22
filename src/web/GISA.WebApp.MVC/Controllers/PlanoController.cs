using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class PlanoController : MainController
    {
        private readonly IPlanoService _planoService;

        public PlanoController(IPlanoService planoService)
        {
            _planoService = planoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("plano/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _planoService.ObterTodos());
        }

        [Route("plano/editar-plano/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var plano = await _planoService.ObterPorId(id);
            return View(plano);
        }

        [HttpPost]
        [Route("plano/editar-plano")]
        public async Task<IActionResult> Editar(Guid id, PlanoViewModel planoViewModel)
        {
            var plano = await _planoService.ObterPorId(id);
            return View(plano);
        }

        [Route("plano/novo-plano")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [Route("plano/novo-plano")]
        public async Task<IActionResult> Registrar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid) return View(planoViewModel);

            var result = await _planoService.Registrar(planoViewModel);

            if (!result.Sucess)
            {
                // TODO: faço algo
            }

            return View("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id, PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid) return View(planoViewModel);

            var result = await _planoService.Atualizar(planoViewModel);

            if (!result.Sucess)
            {
                // TODO: faço algo
            }

            return View("Index");
        }
    }
}
