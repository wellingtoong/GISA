using GISA.Core.DomainObjects;
using System;

namespace GISA.Convenio.API.Domain
{
    public class Convenio : Entity, IAggregateRoot
    {
        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public string InscricaoMunicipal { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string Cnpj { get; private set; }
        public string Telefone { get; private set; }
        public bool Ativo { get; private set; }
        public Email Email { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Convenio() { }

        public Convenio(string nomeFantasia,
                        string razaoSocial,
                        string inscricaoMunicipal,
                        string inscricaoEstadual,
                        string cnpj,
                        string telefone,
                        bool ativo,
                        Email email,
                        Endereco endereco)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            InscricaoMunicipal = inscricaoMunicipal;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            Ativo = ativo;
            Endereco = endereco;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarEndereco(Endereco endereco) => Endereco = endereco;
    }
}
