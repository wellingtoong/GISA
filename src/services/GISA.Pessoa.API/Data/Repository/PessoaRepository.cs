using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PessoaRepository : Repository<Domain.Pessoa>, IPessoaRepository
    {
        public PessoaRepository(PessoaDbContext context) : base(context) { }

        public async Task<IEnumerable<Domain.Pessoa>> ObterTodosComEndereco()
        {
            return await Db.Pessoas.AsNoTracking()
                .Include(e => e.EnderecoPessoa)
                .Include(p => p.PlanoCliente).ToListAsync();
        }

        public async Task<Domain.Pessoa> ObterPessoaComEndereco(Guid id)
        {
            return await Db.Pessoas.AsNoTracking()
                .Include(p => p.PlanoCliente)
                .Include(e => e.EnderecoPessoa).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Domain.Pessoa> ObterPessoaPorEmail(string email)
        {
            return await Db.Pessoas.AsNoTracking().FirstOrDefaultAsync(e => e.Email.Endereco == email);
        }

        public async Task<int> ObterTotalUsuario()
        {
            return await Db.Pessoas.AsNoTracking().CountAsync();
        }

        public async Task<int> ObterTotalUsuarioAtivo()
        {
            return await Db.Pessoas.AsNoTracking().Where(p => p.Ativo).CountAsync();
        }

        public async Task<int> ObterTotalUsuarioInativo()
        {
            return await Db.Pessoas.AsNoTracking().Where(p => !p.Ativo).CountAsync();
        }
    }
}
