using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Task<bool> Adicionar(Domain.Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Guid id, Domain.Pessoa convenio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarEndereco(Guid id, Domain.Pessoa convenio)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _pessoaRepository?.Dispose();
        }

        public Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Pessoa>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
