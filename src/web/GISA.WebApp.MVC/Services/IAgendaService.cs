using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IAgendaService
    {
        Task<AgendaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<AgendaViewModel>> ObterTodos();
        Task<ResponseMessageDefault> Atualizar(AgendaViewModel agendaViewModel);
        Task<ResponseMessageDefault> Registrar(AgendaViewModel agendaViewModel);
    }
}
