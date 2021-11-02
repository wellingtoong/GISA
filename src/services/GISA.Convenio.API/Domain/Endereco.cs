using GISA.Core.DomainObjects;

namespace GISA.Convenio.API.Domain
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

        protected Endereco() { }

        public Endereco(string cep, string logradouro, string numero, string bairro, string estado, string municipio)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Estado = estado;
            Municipio = municipio;
        }
    }
}
