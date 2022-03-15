using System;
using GISA.Core.DomainObjects;

namespace GISA.Pessoa.API.Domain
{
    public class Agenda : Entity, IAggregateRoot
    {
        public Guid IdPessoa { get; private set; }
        public DateTime Data { get; private set; }
        public string Hora { get; private set; }
        public string? Observacao { get; private set; }
        public DateTime DataCadastro { get; private set; }

        protected Agenda() { }

        public Agenda(Guid idPessoa, DateTime data, string hora, string observacao)
        {
            IdPessoa = idPessoa;
            Data = data;
            Hora = hora;
            Observacao = observacao;
            DataCadastro = DateTime.Now;
        }
    }
}