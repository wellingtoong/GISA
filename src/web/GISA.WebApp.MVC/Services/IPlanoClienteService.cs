using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IPlanoClienteService
    {
        Task<PlanoClienteViewModel> ObterPorId(Guid id);
        Task<PlanoClienteViewModel> ObterPorPessoaId(Guid id);
        Task<IEnumerable<PlanoClienteViewModel>> ObterTodos();
        Task<ResponseMessageDefault> Atualizar(PlanoClienteViewModel planoClienteViewModel);
        Task<ResponseMessageDefault> Registrar(PlanoClienteViewModel planoClienteViewModel);
    }
}
