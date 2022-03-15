﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GISA.WebApp.MVC.Models;

namespace GISA.WebApp.MVC.Services
{
    public interface IPlanoClienteService
    {
        Task<PlanoClienteViewModel> ObterPorId(Guid id);
        Task<PlanoClienteViewModel> ObterPorPessoaId(Guid id);
        Task<IEnumerable<PlanoClienteViewModel>> ObterTodos();
        Task<ResponseResult> Atualizar(PlanoClienteViewModel planoClienteViewModel);
        Task<ResponseResult> Registrar(PlanoClienteViewModel planoClienteViewModel);
    }
}
