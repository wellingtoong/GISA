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
            return await Db.Convenios.AsNoTracking().Include(e => e.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await Db.Enderecos.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Convenio>> ObterTodosConvenioEndereco()
        {
            return await Db.Convenios.AsNoTracking().Include(e => e.Endereco).ToListAsync();
        }
    }
}
