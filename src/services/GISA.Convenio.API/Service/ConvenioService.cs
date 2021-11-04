using AutoMapper;
using GISA.Convenio.API.Data.Repository;
using GISA.Convenio.API.Models;
using System;
using System.Collections.Generic;
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

        public async Task<int> Adicionar(Domain.Convenio convenio)
        {
            return await _convenioRepository.Adicionar(convenio);
        }

        public Task Atualizar(Domain.Convenio convenio)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _convenioRepository?.Dispose();
        }

        public async Task<IEnumerable<Domain.Convenio>> ObterTodos()
        {
            return await _convenioRepository.ObterTodos();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
