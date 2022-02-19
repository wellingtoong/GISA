namespace GISA.Pessoa.API.Data.Repository
{
    public class AgendaRepository : Repository<Domain.Agenda>, IAgendaRepository
    {
        public AgendaRepository(ApplicationDbContext context) : base(context) { }
    }
}
