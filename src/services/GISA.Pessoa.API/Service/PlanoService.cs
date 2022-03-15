using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Domain;

namespace GISA.Pessoa.API.Service
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoService(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public async Task<bool> Adicionar(Plano plano) => await _planoRepository.Adicionar(plano);

        public async Task<bool> Atualizar(Plano plano) => await _planoRepository.Atualizar(plano);

        public async Task<IEnumerable<Plano>> ObterTodos() => await _planoRepository.ObterTodos();

        public async Task<int> ObterTotalPlano() => await _planoRepository.ObterTotalPlano();

        public async Task<int> ObterTotalPlanoAtivo() => await _planoRepository.ObterTotalPlanoAtivo();

        public async Task<int> ObterTotalPlanoInativo() => await _planoRepository.ObterTotalPlanoInativo();

        public void Dispose() => _planoRepository?.Dispose();
    }
}