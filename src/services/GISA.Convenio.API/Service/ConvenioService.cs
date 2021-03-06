using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.Convenio.API.Data.Repository;

namespace GISA.Convenio.API.Service
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _convenioRepository;

        public ConvenioService(IConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;
        }

        public async Task<bool> Adicionar(Domain.Convenio convenio) => await _convenioRepository.Adicionar(convenio);

        public async Task<bool> Atualizar(Guid id, Domain.Convenio convenio)
        {
            var enderecoAtual = await _convenioRepository.ObterEnderecoPorId(id);
            convenio.AlterarEndereco(enderecoAtual);

            return await _convenioRepository.Atualizar(convenio);
        }

        public async Task<bool> AtualizarEndereco(Guid id, Domain.Convenio convenio)
        {
            var convenioAtual = await _convenioRepository.ObterConvenioEnderecoPorId(id);
            convenioAtual.AlterarEndereco(convenio.EnderecoConvenio);

            return await _convenioRepository.Atualizar(convenioAtual);
        }

        public async Task<Domain.EnderecoConvenio> ObterEnderecoPorId(Guid id) => await _convenioRepository.ObterEnderecoPorId(id);

        public async Task<IEnumerable<Domain.Convenio>> ObterTodos() => await _convenioRepository.ObterTodos();

        public async Task<int> ObterTotalConvenio() => await _convenioRepository.ObterTotalConvenio();

        public void Dispose() => _convenioRepository?.Dispose();
    }
}
