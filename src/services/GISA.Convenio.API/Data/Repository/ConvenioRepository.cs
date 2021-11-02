namespace GISA.Convenio.API.Data.Repository
{
    public class ConvenioRepository : Repository<Domain.Convenio>, IConvenioRepository
    {
        public ConvenioRepository(ConvenioDbContext context) : base(context) { }

        // TODO: meus metodos
    }
}
