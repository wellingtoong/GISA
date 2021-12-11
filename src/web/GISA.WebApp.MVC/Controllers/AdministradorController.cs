using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class AdministradorController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
