using GISA.Convenio.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Data.Repository
{
    public class ConvenioRepository : Repository<Domain.Convenio>, IConvenioRepository
    {
        public ConvenioRepository(ConvenioDbContext context) : base(context) { }

        public async Task<Domain.Convenio> ObterConvenioEnderecoPorId(Guid id)
        {
            return await Db.Convenios.AsNoTracking()
                .Include(e => e.EnderecoConvenio).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<EnderecoConvenio> ObterEnderecoPorId(Guid id)
        {
            return await Db.EnderecoConvenio.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Convenio>> ObterTodosConvenioEndereco()
        {
            return await Db.Convenios.AsNoTracking()
                .Include(e => e.EnderecoConvenio).ToListAsync();
        }

        public async Task<int> ObterTotalConvenio()
        {
            return await Db.Convenios.AsNoTracking().CountAsync();
        }
    }
}
