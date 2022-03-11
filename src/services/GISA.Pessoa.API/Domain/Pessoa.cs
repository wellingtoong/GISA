using GISA.Core.DomainObjects;
using GISA.Pessoa.API.Enums;
using System;

namespace GISA.Pessoa.API.Domain
{
    public class Pessoa : Entity, IAggregateRoot
    {
        public string NomeCompleto { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public bool Ativo { get; private set; }
        public Email Email { get; private set; }
        public EnderecoPessoa EnderecoPessoa { get; private set; }
        public PlanoCliente? PlanoCliente { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TipoPessoaEnum TipoPessoaEnum { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Pessoa() { }

        public Pessoa(string nomeCompleto, 
                      string rg, 
                      string cpf,
                      string telefone,
                      bool ativo,
                      Email email,
                      DateTime dataNascimento,
                      EnderecoPessoa enderecoPessoa, 
                      TipoPessoaEnum tipoPessoaEnum, 
                      PlanoCliente planoCliente)
        {
            NomeCompleto = nomeCompleto;
            Rg = rg;
            Cpf = cpf;
            Telefone = telefone;
            Ativo = ativo;
            EnderecoPessoa = enderecoPessoa;
            Email = email;
            DataNascimento = dataNascimento;
            TipoPessoaEnum = tipoPessoaEnum;
            DataCadastro = DateTime.Now;
            PlanoCliente = planoCliente;
        }
    }
}
