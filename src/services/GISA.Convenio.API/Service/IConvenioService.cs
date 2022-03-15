using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.Convenio.API.Domain;

namespace GISA.Convenio.API.Service
{
    public interface IConvenioService : IDisposable
    {
        Task<IEnumerable<Domain.Convenio>> ObterTodos();
        Task<EnderecoConvenio> ObterEnderecoPorId(Guid id);
        Task<bool> Adicionar(Domain.Convenio convenio);
        Task<bool> Atualizar(Guid id, Domain.Convenio convenio);
        Task<bool> AtualizarEndereco(Guid id, Domain.Convenio convenio);
        Task<int> ObterTotalConvenio();
    }
}
