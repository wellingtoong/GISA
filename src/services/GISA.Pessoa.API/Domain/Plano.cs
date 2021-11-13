﻿using GISA.Core.DomainObjects;
using GISA.Pessoa.API.Enums;
using System;

namespace GISA.Pessoa.API.Domain
{
    public class Plano : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public TipoPlanoEnum TipoPlanoEnum { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Plano() { }
    }
}
