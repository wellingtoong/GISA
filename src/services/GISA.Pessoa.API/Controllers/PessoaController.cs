using Microsoft.AspNetCore.Mvc;

namespace GISA.Pessoa.API.Controllers
{
    [ApiController]
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
