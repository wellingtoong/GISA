using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IAgendaService
    {
        Task<AgendaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<AgendaViewModel>> ObterAgendamentosPorPessoaId(Guid id);
        Task<IEnumerable<AgendaViewModel>> ObterTodos();
        Task<ResponseResult> Atualizar(AgendaViewModel agendaViewModel);
        Task<ResponseResult> Registrar(AgendaViewModel agendaViewModel);
    }
}
