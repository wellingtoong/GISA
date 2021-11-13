namespace GISA.Pessoa.API.Data.Repository
{
    public class PlanoRepository : Repository<Domain.Plano>, IPlanoRepository
    {
        public PlanoRepository(ApplicationDbContext context) : base(context) { }
    }
}
