using System;
using System.Threading.Tasks;
using GISA.Core.Data;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IPlanoClienteRepository : IRepository<Domain.PlanoCliente>
    {
        Task<bool> PessoaAtivo(Guid id);
        Task<bool> PlanoAtivo(Guid id);
        Task<Domain.PlanoCliente> ObterPlanoClientePorPessoaId(Guid id);
    }
}
