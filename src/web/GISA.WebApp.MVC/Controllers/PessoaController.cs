using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class PessoaController : MainController
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("pessoa/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _pessoaService.ObterTodos());
        }

        [Route("pessoa/obter-pessoa/{id:guid}")]
        public async Task<IActionResult> ObterPessoaPorId(Guid id)
        {
            return Json(await _pessoaService.ObterPorId(id));
        }

        [Route("pessoa/editar-pessoa/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var pessoa = await _pessoaService.ObterPorId(id);
            return View(pessoa);
        }

        [Route("pessoa/obter-pessoa/{email}")]
        public async Task<IActionResult> ObterPorEmail(string email)
        {
            var pessoa = await _pessoaService.ObterPorEmail(email);
            return Json(pessoa);
        }

        [HttpPost]
        [Route("pessoa/editar-pessoa")]
        public async Task<IActionResult> Editar(Guid id, PessoaViewModel pessoaViewModel)
        {
            var pessoa = await _pessoaService.ObterPorId(id);
            return View(pessoa);
        }

        [Route("pessoa/novo-pessoa")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [Route("pessoa/novo-pessoa")]
        public async Task<IActionResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                return View(pessoaViewModel);
            }

            var result = await _pessoaService.Registrar(pessoaViewModel);

            if (!result.Sucess)
            {
                // TODO: faço algo
            }

            return View("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id, PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                return View("Editar", pessoaViewModel);
            }

            var result = await _pessoaService.Atualizar(pessoaViewModel);

            if (!result.Sucess)
            {
                // TODO: faço algo
            }

            return View("Index");
        }
    }
}
