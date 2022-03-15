using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;

namespace GISA.WebApp.MVC.Services
{
    public interface IConvenioService
    {
        Task<ConvenioViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ConvenioViewModel>> ObterTodos();
        Task<ResponseResult> Atualizar(ConvenioViewModel convenioViewModel);
        Task<ResponseResult> Registrar(ConvenioViewModel convenioViewModel);
        Task<int> ObterTotalConvenio();
    }
}
