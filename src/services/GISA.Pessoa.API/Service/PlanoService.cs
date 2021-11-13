using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Service
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;
        public PlanoService(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public async Task<bool> Adicionar(Plano plano)
        {
            return await _planoRepository.Adicionar(plano);
        }

        public async Task<bool> Atualizar(Plano plano)
        {
            return await _planoRepository.Atualizar(plano);
        }

        public async Task<IEnumerable<Plano>> ObterTodos()
        {
            return await _planoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _planoRepository?.Dispose();
        }
    }
}
