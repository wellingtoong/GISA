using System;
using GISA.Core.DomainObjects;

namespace GISA.Convenio.API.Domain
{
    public class EnderecoConvenio : Entity
    {
        public Guid ConvenioId { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public string Municipio { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Convenio Convenio { get; set; }

        protected EnderecoConvenio() { }

        public EnderecoConvenio(
            string cep,
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string estado,
            string municipio,
            Guid convenioId)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Estado = estado;
            Municipio = municipio;
            ConvenioId = convenioId;
            DataCadastro = DateTime.Now;
        }
    }
}
