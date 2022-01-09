using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IConvenioService
    {
        Task<ConvenioViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ConvenioViewModel>> ObterTodos();
        Task<ResponseMessageDefault> Atualizar(ConvenioViewModel convenioViewModel);
        Task<ResponseMessageDefault> Registrar(ConvenioViewModel convenioViewModel);
    }
}
