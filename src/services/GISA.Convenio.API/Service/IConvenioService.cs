using GISA.Convenio.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Service
{
    public interface IConvenioService : IDisposable
    {
        Task<int> Adicionar(ConvenioViewModel convenio);
        Task Atualizar(ConvenioViewModel convenio);

        Task<IList<ConvenioViewModel>> ObterTodos();
        Task Remover(Guid id);
    }
}
