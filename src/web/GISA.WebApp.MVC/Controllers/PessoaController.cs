using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    public class PessoaController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
