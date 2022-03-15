using System.Linq;
using GISA.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GISA.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Count > 0)
            {
                foreach (var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }

        protected void AdicionarErroValidacao(string mensagem)
            => ModelState.AddModelError(string.Empty, mensagem);

        protected bool OperacaoValida() => ModelState.ErrorCount == 0;
    }
}