using GISA.Pessoa.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PessoaRepository : Repository<Domain.Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Domain.Pessoa> ObterPessoaEnderecoPorId(Guid id) => await Db.Pessoas.AsNoTracking().Include(e => e.Endereco).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Endereco> ObterEnderecoPorId(Guid id) => await Db.Enderecos.FindAsync(id);

        public async Task<IEnumerable<Domain.Pessoa>> ObterTodasPessoasEndereco() => await Db.Pessoas.AsNoTracking().Include(e => e.Endereco).ToListAsync();

        public async Task<Domain.Pessoa> ObterPessoaPorEmail(string email) => await Db.Pessoas.AsNoTracking().FirstOrDefaultAsync(e => e.Email.Endereco == email);

        public async Task<int> ObterTotalUsuario() => await Db.Pessoas.AsNoTracking().CountAsync();

        public async Task<int> ObterTotalUsuarioAtivo() => await Db.Pessoas.AsNoTracking().Where(p => p.Ativo).CountAsync();

        public async Task<int> ObterTotalUsuarioInativo() => await Db.Pessoas.AsNoTracking().Where(p => !p.Ativo).CountAsync();
    }
}
