using System;
using System.Linq;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        [Route("pessoa")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("pessoa/todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _pessoaService.ObterTodos());
        }

        [HttpGet]
        [Route("pessoa/{id:guid}")]
        public async Task<IActionResult> ObterPessoaPorId(Guid id)
        {
            return Json(await _pessoaService.ObterPorId(id));
        }

        [HttpGet]
        [Route("pessoa/{email}")]
        public async Task<IActionResult> ObterPorEmail(string email)
        {
            var pessoa = await _pessoaService.ObterPorEmail(email);
            return Json(pessoa);
        }

        [HttpGet]
        [Route("pessoa/editar/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var planos = await _planoService.ObterTodos();

            ViewBag.TipoPlano = planos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            var pessoa = await _pessoaService.ObterPorId(id);
            return View(pessoa);
        }

        [HttpPost]
        [Route("pessoa/editar")]
        public async Task<IActionResult> Editar(Guid id, PessoaViewModel pessoaViewModel)
        {
            var pessoa = await _pessoaService.ObterPorId(id);
            return View(pessoa);
        }

        [HttpGet]
        [Route("pessoa/novo")]
        public IActionResult Registrar()
        {
            ViewBag.ValidateForm = true;
            return View();
        }

        [HttpPost]
        [Route("pessoa/novo")]
        public async Task<IActionResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                AdicionarErroValidacao("Verifique os dados preenchidos e tente novamente.");
                return View(pessoaViewModel);
            }

            var result = await _pessoaService.Registrar(pessoaViewModel);

            return ResponsePossuiErros(result) ? View("Registrar") : (IActionResult)RedirectToAction("Index", "Pessoa");
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

            return ResponsePossuiErros(result) ? View("Editar") : (IActionResult)RedirectToAction("Index", "Pessoa");
        }

        private void CalcularDesconto(PessoaViewModel pessoaViewModel, PlanoViewModel planoViewModel)
        {
            var vd = planoViewModel.Valor * (pessoaViewModel.PlanoClienteViewModel.Desconto / 100);
            var vf = planoViewModel.Valor - vd;

            pessoaViewModel.PlanoClienteViewModel.ValorFinal = vf;
        }
    }
}
