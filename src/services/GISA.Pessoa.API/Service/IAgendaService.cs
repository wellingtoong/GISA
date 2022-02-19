using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public interface IAgendaService : IDisposable
    {
        Task<bool> Adicionar(Domain.Agenda agenda);
        Task<bool> Atualizar(Domain.Agenda agenda);
        Task<Domain.Agenda> ObterPorId(Guid id);
        Task<IEnumerable<Domain.Agenda>> ObterTodos();
    }
}
