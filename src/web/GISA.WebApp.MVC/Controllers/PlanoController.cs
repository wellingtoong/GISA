using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    public class PlanoController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
