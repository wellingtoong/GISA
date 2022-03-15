using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PlanoClienteRepository : Repository<Domain.PlanoCliente>, IPlanoClienteRepository
    {
        public PlanoClienteRepository(PessoaDbContext context) : base(context)
        {
        }

        public async Task<bool> PessoaAtivo(Guid id)
        {
            var pessoa = await Db.Pessoas.FirstOrDefaultAsync(p => p.Id == id && p.Ativo);
            return pessoa != null;
        }

        public async Task<bool> PlanoAtivo(Guid id)
        {
            var plano = await Db.Planos.FirstOrDefaultAsync(p => p.Id == id && p.Ativo);
            return plano != null;
        }

        public async Task<Domain.PlanoCliente> ObterPlanoClientePorPessoaId(Guid id)
            => await Db.PlanoClientes.AsNoTracking().FirstOrDefaultAsync(c => c.PessoaId == id);
    }
}
