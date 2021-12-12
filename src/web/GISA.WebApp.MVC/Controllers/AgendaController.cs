using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    public class AgendaController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
