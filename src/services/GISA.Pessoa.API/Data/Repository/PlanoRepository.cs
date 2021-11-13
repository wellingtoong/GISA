using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data.Repository
{
    public class PlanoRepository : Repository<Domain.Plano>, IPlanoRepository
    {
        public PlanoRepository(ApplicationDbContext context) : base(context) { }
    }
}
