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
        Task<ResponseMessageDefault> Atualizar(PessoaViewModel pessoaViewModel);
        Task<ResponseMessageDefault> Registrar(PessoaViewModel pessoaViewModel);
        Task<int> ObterTotalUsuario();
        Task<int> ObterTotalUsuarioAtivo();
        Task<int> ObterTotalUsuarioInativo();
    }
}
