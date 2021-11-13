using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public interface IPlanoService : IDisposable
    {
        Task<bool> Adicionar(Domain.Plano plano);
        Task<bool> Atualizar(Domain.Plano plano);
        Task<IEnumerable<Domain.Plano>> ObterTodos();
    }
}
