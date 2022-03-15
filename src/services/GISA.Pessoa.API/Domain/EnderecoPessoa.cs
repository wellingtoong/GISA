using System;
using GISA.Core.DomainObjects;

namespace GISA.Pessoa.API.Domain
{
    public class EnderecoPessoa : Entity
    {
        public Guid PessoaId { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public string Municipio { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Pessoa Pessoa { get; private set; }

        protected EnderecoPessoa() { }

        public EnderecoPessoa(
            string cep,
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string estado,
            string municipio,
            Guid pessoaId)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
            Municipio = municipio;
            PessoaId = pessoaId;
            DataCadastro = DateTime.Now;
        }
    }
}
