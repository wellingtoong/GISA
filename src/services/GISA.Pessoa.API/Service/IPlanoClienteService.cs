using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public interface IPlanoClienteService : IDisposable
    {
        Task<bool> Adicionar(Domain.PlanoCliente planoCliente);
        Task<bool> Atualizar(Guid id, Domain.PlanoCliente planoCliente);
        Task<IEnumerable<Domain.PlanoCliente>> ObterTodos();
    }
}
