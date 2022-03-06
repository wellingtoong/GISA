﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PlanoClienteRepository : Repository<Domain.PlanoCliente>, IPlanoClienteRepository
    {
        public PlanoClienteRepository(PessoaDbContext context) : base(context) { }

        public async Task<bool> PessoaAtivo(Guid id)
        {
            var pessoa = await Db.Pessoas.FirstOrDefaultAsync(p => p.Id == id && p.Ativo);

            if (pessoa == null) return false;

            return true;
        }

        public async Task<bool> PlanoAtivo(Guid id)
        {
            var plano = await Db.Planos.FirstOrDefaultAsync(p => p.Id == id && p.Ativo);

            if (plano == null) return false;

            return true;
        }

        public async Task<Domain.PlanoCliente> ObterPlanoClientePorPessoaId(Guid id)
        {
            return await Db.PlanoClientes.AsNoTracking().FirstOrDefaultAsync(c => c.PessoaId == id);
        }
    }
}
