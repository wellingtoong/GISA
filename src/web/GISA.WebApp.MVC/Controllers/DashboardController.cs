using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    public class DashboardController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
