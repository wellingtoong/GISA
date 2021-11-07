﻿using GISA.Pessoa.API.Service;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PessoaRepository : Repository<Domain.Pessoa>, IPessoaService
    {
        public PessoaRepository(ApplicationDbContext context) : base(context) { }
    }
}
