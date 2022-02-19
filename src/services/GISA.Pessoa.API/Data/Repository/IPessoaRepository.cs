﻿using GISA.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public interface IPessoaRepository : IRepository<Domain.Pessoa>
    {
        Task<Domain.Pessoa> ObterPessoaEnderecoPorId(Guid id);
        Task<IEnumerable<Domain.Pessoa>> ObterTodasPessoasEndereco();
        Task<Domain.Endereco> ObterEnderecoPorId(Guid id);
        Task<Domain.Pessoa> ObterPessoaPorEmail(string email);
    }
}
