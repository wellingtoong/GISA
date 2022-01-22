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
        public virtual Endereco Endereco { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TipoPessoaEnum TipoPessoaEnum { get; private set; }

        protected Pessoa() { }

        public Pessoa(string nomeCompleto, 
                      string rg, 
                      string cpf,
                      string telefone,
                      bool ativo,
                      Email email,
                      DateTime dataNascimento,
                      Endereco endereco, 
                      TipoPessoaEnum tipoPessoaEnum)
        {
            NomeCompleto = nomeCompleto;
            Rg = rg;
            Cpf = cpf;
            Telefone = telefone;
            Ativo = ativo;
            Endereco = endereco;
            Email = email;
            DataNascimento = dataNascimento;
            TipoPessoaEnum = tipoPessoaEnum;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarEndereco(Endereco endereco) => Endereco = endereco;
    }
}
