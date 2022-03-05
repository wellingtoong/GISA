using GISA.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IAgendaRepository : IRepository<Domain.Agenda>
    {
        Task<IEnumerable<Domain.Agenda>> ObterAgendamentosPorIdPessoa(Guid id);
    }
}
