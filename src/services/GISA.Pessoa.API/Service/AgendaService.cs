using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Domain;

namespace GISA.Pessoa.API.Service
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<bool> Adicionar(Agenda agenda)
        {
            return await _agendaRepository.Adicionar(agenda);
        }

        public async Task<bool> Atualizar(Agenda agenda)
        {
            return await _agendaRepository.Atualizar(agenda);
        }

        public async Task<Agenda> ObterPorId(Guid id)
        {
            return await _agendaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Agenda>> ObterTodos()
        {
            return await _agendaRepository.ObterTodos();
        }
        public void Dispose()
        {
            _agendaRepository?.Dispose();
        }
    }
}
