﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class PlanoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}