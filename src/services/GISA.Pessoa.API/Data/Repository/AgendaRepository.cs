﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GISA.Pessoa.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace GISA.Pessoa.API.Data.Repository
{
    public class AgendaRepository : Repository<Domain.Agenda>, IAgendaRepository
    {
        public AgendaRepository(PessoaDbContext context) : base(context) { }

        public async Task<IEnumerable<Agenda>> ObterAgendamentosPorIdPessoa(Guid id)
        {
            return await Db.Agendas.AsNoTracking()
                .Where(a => a.IdPessoa == id).ToListAsync();
        }
    }
}
