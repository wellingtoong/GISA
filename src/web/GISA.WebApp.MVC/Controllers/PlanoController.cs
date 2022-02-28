﻿using GISA.WebApp.MVC.Models;
using GISA.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class PlanoController : MainController
    {
        private readonly IPlanoService _planoService;

        public PlanoController(IPlanoService planoService)
        {
            _planoService = planoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("plano/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Json(await _planoService.ObterTodos());
        }

        [Route("plano/editar-plano/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var plano = await _planoService.ObterPorId(id);

            return View(plano);
        }

        [HttpPost]
        [Route("plano/editar-plano")]
        public async Task<IActionResult> Editar(Guid id, PlanoViewModel planoViewModel)
        {
            var plano = await _planoService.ObterPorId(id);

            return View(plano);
        }

        [Route("plano/novo-plano")]
        public IActionResult Registrar()
        {
            ViewBag.ValidateForm = false;
            return View();
        }

        [HttpPost]
        [Route("plano/novo-plano")]
        public async Task<IActionResult> Registrar(PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                return View(planoViewModel);
            }

            var result = await _planoService.Registrar(planoViewModel);

            if (ResponsePossuiErros(result)) return View("Registrar");

            return RedirectToAction("Index", "Plano");
        }

        public async Task<IActionResult> Atualizar(Guid id, PlanoViewModel planoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidateForm = true;
                return View("Editar", planoViewModel);
            }

            var result = await _planoService.Atualizar(planoViewModel);

            if (ResponsePossuiErros(result)) return View("Editar");

            return RedirectToAction("Index", "Plano");
        }
    }
}
