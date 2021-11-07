using GISA.Convenio.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Service
{
    public interface IConvenioService : IDisposable
    {
        Task<bool> Adicionar(Domain.Convenio convenio);
        Task<bool> Atualizar(Guid id, Domain.Convenio convenio);
        Task<Endereco> ObterEnderecoPorId(Guid id);
        Task<bool> AtualizarEndereco(Guid id, Domain.Convenio convenio);
        Task<IEnumerable<Domain.Convenio>> ObterTodos();
    }
}
