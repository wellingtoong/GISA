using GISA.Pessoa.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public interface IPessoaService : IDisposable
    {
        Task<bool> Adicionar(Domain.Pessoa pessoa);
        Task<bool> Atualizar(Guid id, Domain.Pessoa convenio);
        //Task<Endereco> ObterEnderecoPorId(Guid id);
        //Task<bool> AtualizarEndereco(Guid id, Domain.Pessoa convenio);
        Task<IEnumerable<Domain.Pessoa>> ObterTodos();
        Task<int> ObterTotalUsuario();
        Task<int> ObterTotalUsuarioAtivo();
        Task<int> ObterTotalUsuarioInativo();
    }
}
