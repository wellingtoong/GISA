﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PlanoRepository : Repository<Domain.Plano>, IPlanoRepository
    {
        public PlanoRepository(PessoaDbContext context) : base(context) { }

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
