using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IPlanoService
    {
        Task<PlanoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<PlanoViewModel>> ObterTodos();
        Task<ResponseMessageDefault> Atualizar(PlanoViewModel planoViewModel);
        Task<ResponseMessageDefault> Registrar(PlanoViewModel planoViewModel);
    }
}
