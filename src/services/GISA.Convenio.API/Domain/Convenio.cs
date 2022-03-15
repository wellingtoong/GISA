﻿using System;
using GISA.Core.DomainObjects;

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
        public EnderecoConvenio EnderecoConvenio { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Convenio() { }

        public Convenio(string nomeFantasia,
                        string razaoSocial,
                        string inscricaoMunicipal,
                        string inscricaoEstadual,
                        string cnpj,
                        string telefone,
                        bool ativo,
                        Email email,
                        EnderecoConvenio enderecoConvenio)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            InscricaoMunicipal = inscricaoMunicipal;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            Ativo = ativo;
            EnderecoConvenio = enderecoConvenio;
            DataCadastro = DateTime.Now;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarEndereco(EnderecoConvenio endereco) => EnderecoConvenio = endereco;
    }
}
