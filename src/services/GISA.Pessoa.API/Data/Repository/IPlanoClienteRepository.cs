using GISA.Core.Data;
using System;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IPlanoClienteRepository : IRepository<Domain.PlanoCliente>
    {
        Task<bool> PessoaAtivo(Guid id);
        Task<bool> PlanoAtivo(Guid id);
        Task<Domain.PlanoCliente> ObterPlanoClientePorPessoaId(Guid id);
    }
}
