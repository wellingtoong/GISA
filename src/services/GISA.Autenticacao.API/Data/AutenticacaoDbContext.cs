﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GISA.Autenticacao.API.Data
{
    public class AutenticacaoDbContext : IdentityDbContext
    {
        public AutenticacaoDbContext(DbContextOptions<AutenticacaoDbContext> options) : base(options) { }
    }
}