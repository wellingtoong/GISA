using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.Core.Data;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IPessoaRepository : IRepository<Domain.Pessoa>
    {
        Task<IEnumerable<Domain.Pessoa>> ObterTodosComEndereco();
        Task<Domain.Pessoa> ObterPessoaComEndereco(Guid id);
        Task<Domain.Pessoa> ObterPessoaPorEmail(string email);
        Task<int> ObterTotalUsuario();
        Task<int> ObterTotalUsuarioAtivo();
        Task<int> ObterTotalUsuarioInativo();
    }
}
