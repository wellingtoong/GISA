using System;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Service
{
    public interface IConvenioService : IDisposable
    {
        Task Adicionar(Domain.Convenio convenio);
        Task Atualizar(Domain.Convenio convenio);
        Task Remover(Guid id);
    }
}
