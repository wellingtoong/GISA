using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    [Authorize]
    public class DashboardController : MainController
    {
        private readonly IConvenioService _convenioService;
        private readonly IPessoaService _pessoaService;
        private readonly IPlanoService _planoService;

        public DashboardController(IConvenioService convenioService, IPessoaService pessoaService, IPlanoService planoService)
        {
            _convenioService = convenioService;
            _pessoaService = pessoaService;
            _planoService = planoService;
        }

        [HttpGet]
        [Route("dashboard")]
        public async Task<IActionResult> Index()
        {
            var obterTotalConvenio = await _convenioService.ObterTotalConvenio();

            var obterTotalUsuario = await _pessoaService.ObterTotalUsuario();
            var obterTotalUsuarioAtivo = await _pessoaService.ObterTotalUsuarioAtivo();
            var obterTotalUsuarioInativo = await _pessoaService.ObterTotalUsuarioInativo();

            var obterTotalPlano = await _planoService.ObterTotalPlano();
            var obterTotalPlanoAtivo = await _planoService.ObterTotalPlanoAtivo();
            var obterTotalPlanoInativo = await _planoService.ObterTotalPlanoInativo();

            return View(new DashboardViewModels
            {
                TotalUsuario = obterTotalUsuario,
                TotalAtivo = obterTotalUsuarioAtivo,
                TotalInativo = obterTotalUsuarioInativo,
                TotalConvenio = obterTotalConvenio,
                TotalPlano = obterTotalPlano,
                PlanoVendido = obterTotalPlanoAtivo,
                PlanoCancelado = obterTotalPlanoInativo,
            });
        }
    }
}
