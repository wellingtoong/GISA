using GISA.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Data.Repository
{
    public interface IConvenioRepository : IRepository<Domain.Convenio>
    {
        Task<Domain.Convenio> ObterConvenioEnderecoPorId(Guid id);
        Task<IEnumerable<Domain.Convenio>> ObterTodosConvenioEndereco();
        Task<Domain.Endereco> ObterEnderecoPorId(Guid id);
        Task<int> ObterTotalConvenio();
    }
}
