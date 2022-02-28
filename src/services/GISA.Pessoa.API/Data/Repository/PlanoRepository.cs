using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PlanoRepository : Repository<Domain.Plano>, IPlanoRepository
    {
        public PlanoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> ObterTotalPlano()
        {
            return await Db.Planos.AsNoTracking().CountAsync();
        }

        public async Task<int> ObterTotalPlanoAtivo()
        {
            return await Db.Planos.AsNoTracking().Where(p => p.Ativo).CountAsync();
        }

        public async Task<int> ObterTotalPlanoInativo()
        {
            return await Db.Planos.AsNoTracking().Where(p => p.Ativo).CountAsync(); 
        }
    }
}
