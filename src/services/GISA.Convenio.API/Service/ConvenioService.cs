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
        private readonly IMapper _mapper;
        private readonly IConvenioRepository _convenioRepository;

        public ConvenioService(IConvenioRepository convenioRepository,
                               IMapper mapper)
        {
            _convenioRepository = convenioRepository;
            _mapper = mapper;
        }

        public async Task<int> Adicionar(ConvenioViewModel convenio)
        {
            return await _convenioRepository.Adicionar(_mapper.Map<Domain.Convenio>(convenio));
        }

        public Task Atualizar(ConvenioViewModel convenio)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _convenioRepository?.Dispose();
        }

        public async Task<IList<ConvenioViewModel>> ObterTodos()
        {
            return _mapper.Map<IList<ConvenioViewModel>>(await _convenioRepository.ObterTodos());
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
