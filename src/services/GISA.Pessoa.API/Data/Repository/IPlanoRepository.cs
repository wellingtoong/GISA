using System.Threading.Tasks;
using GISA.Core.Data;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IPlanoRepository : IRepository<Domain.Plano>
    {
        Task<int> ObterTotalPlano();
        Task<int> ObterTotalPlanoAtivo();
        Task<int> ObterTotalPlanoInativo();
    }
}
