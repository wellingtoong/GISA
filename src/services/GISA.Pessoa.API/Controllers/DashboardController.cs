using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GISA.Pessoa.API.Controllers
{
    [Route("api/dashboard")]
    public class DashboardController : MainController
    {
        public DashboardController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
