using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;

namespace GISA.WebApp.MVC.Services
{
    public interface IPlanoService
    {
        Task<PlanoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<PlanoViewModel>> ObterTodos();
        Task<ResponseResult> Atualizar(PlanoViewModel planoViewModel);
        Task<ResponseResult> Registrar(PlanoViewModel planoViewModel);
        Task<int> ObterTotalPlano();
        Task<int> ObterTotalPlanoAtivo();
        Task<int> ObterTotalPlanoInativo();
    }
}
