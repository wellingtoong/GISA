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

        public async Task<bool> Adicionar(Domain.Pessoa pessoa)
        {
            return await _pessoaRepository.Adicionar(pessoa);
        }

        public async Task<bool> Atualizar(Guid id, Domain.Pessoa pessoa)
        {
            var enderecoAtual = await _pessoaRepository.ObterEnderecoPorId(id);
            pessoa.AlterarEndereco(enderecoAtual);

            return await _pessoaRepository.Atualizar(pessoa);
        }

        public async Task<bool> AtualizarEndereco(Guid id, Domain.Pessoa pessoa)
        {
            var pessoaAtual = await _pessoaRepository.ObterPessoaEnderecoPorId(id);
            pessoaAtual.AlterarEndereco(pessoa.Endereco);

            return await _pessoaRepository.Atualizar(pessoaAtual);
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await _pessoaRepository.ObterEnderecoPorId(id);
        }

        public async Task<IEnumerable<Domain.Pessoa>> ObterTodos()
        {
            return await _pessoaRepository.ObterTodos();
        }

        public void Dispose()
        {
            _pessoaRepository?.Dispose();
        }
    }
}
