﻿using GISA.Core.DomainObjects;
using System;

namespace GISA.Pessoa.API.Domain
{
    public class Endereco : Entity
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public string Municipio { get; private set; }
        public Guid PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Endereco() { }

        public Endereco(string cep, string logradouro, string numero, string complemento, string bairro, string estado, string municipio)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
            Municipio = municipio;
            DataCadastro = DateTime.Now;
        }
    }
}
