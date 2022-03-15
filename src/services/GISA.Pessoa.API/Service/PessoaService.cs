using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.Pessoa.API.Data.Repository;

namespace GISA.Pessoa.API.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> Adicionar(Domain.Pessoa pessoa) => await _pessoaRepository.Adicionar(pessoa);

        public async Task<bool> Atualizar(Guid id, Domain.Pessoa pessoa)
        {
            //var enderecoAtual = await _pessoaRepository.ObterEnderecoPorId(id);
            //pessoa.AlterarEndereco(enderecoAtual);

            return await _pessoaRepository.Atualizar(pessoa);
        }

        //public async Task<bool> AtualizarEndereco(Guid id, Domain.Pessoa pessoa)
        //{
        //    var pessoaAtual = await _pessoaRepository.ObterPessoaEnderecoPorId(id);
        //    pessoaAtual.AlterarEndereco(pessoa.Endereco);

        //    return await _pessoaRepository.Atualizar(pessoaAtual);
        //}

        //public async Task<Endereco> ObterEnderecoPorId(Guid id) => await _pessoaRepository.ObterEnderecoPorId(id);

        public async Task<IEnumerable<Domain.Pessoa>> ObterTodos() => await _pessoaRepository.ObterTodos();

        public async Task<int> ObterTotalUsuario() => await _pessoaRepository.ObterTotalUsuario();

        public async Task<int> ObterTotalUsuarioAtivo() => await _pessoaRepository.ObterTotalUsuarioAtivo();

        public async Task<int> ObterTotalUsuarioInativo() => await _pessoaRepository.ObterTotalUsuarioInativo();

        public void Dispose() => _pessoaRepository?.Dispose();
    }
}