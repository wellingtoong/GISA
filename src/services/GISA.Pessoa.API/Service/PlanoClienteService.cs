using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public class PlanoClienteService : IPlanoClienteService
    {
        private readonly IPlanoClienteRepository _planoClienteRepository;

        public PlanoClienteService(IPlanoClienteRepository planoClienteRepository)
        {
            _planoClienteRepository = planoClienteRepository;
        }

        public async Task<bool> Adicionar(PlanoCliente planoCliente) 
            => await _planoClienteRepository.Adicionar(planoCliente);

        public async Task<bool> Atualizar(Guid id, PlanoCliente planoCliente) 
            => await _planoClienteRepository.Atualizar(planoCliente);

        public async Task<IEnumerable<PlanoCliente>> ObterTodos()
            => await _planoClienteRepository.ObterTodos();

        public void Dispose() => _planoClienteRepository?.Dispose();
    }
}