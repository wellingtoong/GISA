using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class PessoaController : MainController
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPlanoService _planoService;

        public PessoaController(IPessoaService pessoaService, IPlanoService planoService)
        {
            _pessoaService = pessoaService;
            _planoService = planoService;
        }

        [Route("pessoa")]
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

        [Route("pessoa/obter-pessoa/{email}")]
        public async Task<IActionResult> ObterPorEmail(string email)
        {
            var pessoa = await _pessoaService.ObterPorEmail(email);
            return Json(pessoa);
        }

        [Route("pessoa/editar-pessoa/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var planos = await _planoService.ObterTodos();

            ViewBag.TipoPlano = planos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            var pessoa = await _pessoaService.ObterPorId(id);
            return View(pessoa);
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
            ViewBag.ValidateForm = true;
            return View();
        }

        [HttpPost]
        [Route("pessoa/novo-pessoa")]
        public async Task<IActionResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View(pessoaViewModel);
            }

            var result = await _pessoaService.Registrar(pessoaViewModel);

            if (ResponsePossuiErros(result)) return View("Registrar");

            return RedirectToAction("Index", "Pessoa");
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.PlanoClienteViewModel.PessoaId = (Guid)pessoaViewModel.Id;

            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View("Editar", pessoaViewModel);
            }

            var plano = await _planoService.ObterPorId(pessoaViewModel.PlanoClienteViewModel.PlanoId);

            CalcularDesconto(pessoaViewModel, plano);

            var result = await _pessoaService.Atualizar(pessoaViewModel);

            if (ResponsePossuiErros(result)) return View("Editar");

            return RedirectToAction("Index", "Pessoa");
        }

        private void CalcularDesconto(PessoaViewModel pessoaViewModel, PlanoViewModel planoViewModel)
        {
            var vd = planoViewModel.Valor * (pessoaViewModel.PlanoClienteViewModel.Desconto / 100);
            var vf = planoViewModel.Valor - vd;

            pessoaViewModel.PlanoClienteViewModel.ValorFinal = vf;
        }
    }
}
