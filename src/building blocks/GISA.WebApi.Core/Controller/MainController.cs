using System.Collections.Generic;
using System.Linq;
using GISA.Core.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GISA.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected readonly ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
            => OperacaoValida() ? Ok(result) : CreateBadRequest();

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
                AdicionarErroProcessamento(erro.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult resposta)
        {
            ResponsePossuiErros(resposta);
            return OperacaoValida() ? Ok(resposta) : CreateBadRequest();
        }

        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta == null || resposta.Errors.Mensagens.Count == 0)
                return false;

            foreach (var mensagem in resposta.Errors.Mensagens)
                AdicionarErroProcessamento(mensagem);

            return true;
        }

        protected bool OperacaoValida()
            => Erros.Count == 0;

        protected void AdicionarErroProcessamento(string erro)
            => Erros.Add(erro);

        protected void LimparErrosProcessamento()
            => Erros.Clear();

        private BadRequestObjectResult CreateBadRequest()
            => BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> { { "Mensagens", Erros.ToArray() } }));
    }
}