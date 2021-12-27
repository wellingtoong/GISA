using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class ConvenioController : MainController
    {
        private readonly IConvenioService _convenioService;

        public ConvenioController(IConvenioService convenioService)
        {
            _convenioService = convenioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("convenio/novo-registro")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [Route("convenio/novo-registro")]
        public async Task<IActionResult> Registrar(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid) return View(convenioViewModel);

            var result = await _convenioService.Registrar(convenioViewModel);

            if (!result.Sucesso)
            {
                // TODO: faço algo
            }

            return View();
        }
    }
}
