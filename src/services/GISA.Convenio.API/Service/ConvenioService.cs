using GISA.Convenio.API.Data.Repository;
using System;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Service
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _convenioRepository;

        public ConvenioService(IConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;                
        }

        public Task Adicionar(Domain.Convenio convenio)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Domain.Convenio convenio)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
