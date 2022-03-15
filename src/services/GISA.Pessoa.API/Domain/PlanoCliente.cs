﻿using System;
using GISA.Core.DomainObjects;

namespace GISA.Pessoa.API.Domain
{
    public class PlanoCliente : Entity
    {
        public Guid PlanoId { get; private set; }
        public int? Desconto { get; private set; }
        public decimal ValorFinal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Guid PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }

        protected PlanoCliente() { }

        public PlanoCliente(Guid pessoaId, Guid planoId, int desconto, decimal valorFinal)
        {
            PessoaId = pessoaId;
            PlanoId = planoId;
            Desconto = desconto;
            ValorFinal = valorFinal;
            DataCadastro = DateTime.Now;
        }
    }
}
