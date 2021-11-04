using GISA.Convenio.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Service
{
    public interface IConvenioService : IDisposable
    {
        Task<int> Adicionar(Domain.Convenio convenio);
        Task Atualizar(Domain.Convenio convenio);

        Task<IEnumerable<Domain.Convenio>> ObterTodos();
        Task Remover(Guid id);
    }
}
