using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Data.Repository
{
    public class ConvenioRepository : Repository<Domain.Convenio>, IConvenioRepository
    {
        public ConvenioRepository(ConvenioDbContext context) : base(context) { }

        public async Task<Domain.Convenio> ObterConvenioEndereco(Guid id)
        {
            return await Db.Convenios.AsNoTracking().Include(e => e.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
