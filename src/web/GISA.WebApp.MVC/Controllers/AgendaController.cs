using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Controllers
{
    public class AgendaController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("agendamento/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return View();
        }

        [Route("agendamento/editar-agenda/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            //var pessoa = await _pessoaService.ObterPorId(id);
            //return View(pessoa);

            return View();
        }

        [HttpPost]
        [Route("agendamento/editar-pessoa")]
        public async Task<IActionResult> Editar(/*Guid id, AgendaViewModel agendaViewModel*/)
        {
            //var pessoa = await _pessoaService.ObterPorId(id);
            //return View(pessoa);

            return View();
        }

        [Route("agendamento/novo-agenda")]
        public IActionResult Registrar()
        {
            return View();
        }

        //[HttpPost]
        //[Route("agendamento/novo-agenda")]
        //public async Task<IActionResult> Registrar(/*AgendaViewModel agendaViewModel*/)
        //{
        //if (!ModelState.IsValid)
        //{
        //    ViewBag.ValidateForm = true;
        //    return View(pessoaViewModel);
        //}

        //var result = await _pessoaService.Registrar(pessoaViewModel);

        //if (!result.Sucess)
        //{
        //    // TODO: faço algo
        //}

        //    return View("Index");
        //}

        public async Task<IActionResult> Atualizar(/*Guid id, PessoaViewModel pessoaViewModel*/)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.ValidateForm = true;
            //    return View("Editar", pessoaViewModel);
            //}

            //var result = await _pessoaService.Atualizar(pessoaViewModel);

            //if (!result.Sucess)
            //{
            //    // TODO: faço algo
            //}

            return View("Index");
        }
    }
}
