using GISA.Core.DomainObjects;

namespace GISA.Pessoa.API.Domain
{
    public class Dashboard : Entity, IAggregateRoot
    {
        public int TotalUsuario { get; set; }
        public int TotalAtivo { get; set; }
        public int TotalInativo { get; set; }
        public int TotalConvenio { get; set; }
        public int TotalPlano { get; set; }
        public int PlanoVendido { get; set; }
        public int PlanoCancelado { get; set; }
    }
}
