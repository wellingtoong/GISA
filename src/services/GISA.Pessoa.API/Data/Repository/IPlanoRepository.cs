using GISA.Core.Data;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IPlanoRepository : IRepository<Domain.Plano>
    {
        Task<int> ObterTotalPlano();
        Task<int> ObterTotalPlanoAtivo();
        Task<int> ObterTotalPlanoInativo();
    }
}
