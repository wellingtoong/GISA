using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IPessoaService
    {
        Task<PessoaViewModel> ObterPorId(Guid id);
        Task<PessoaViewModel> ObterPorEmail(string email);
        Task<IEnumerable<PessoaViewModel>> ObterTodos();
        Task<ResponseResult> Atualizar(PessoaViewModel pessoaViewModel);
        Task<ResponseResult> Registrar(PessoaViewModel pessoaViewModel);
        Task<int> ObterTotalUsuario();
        Task<int> ObterTotalUsuarioAtivo();
        Task<int> ObterTotalUsuarioInativo();
    }
}
