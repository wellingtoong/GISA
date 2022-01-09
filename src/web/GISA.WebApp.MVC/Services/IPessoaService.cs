﻿using GISA.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IPessoaService
    {
        Task<PessoaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<PessoaViewModel>> ObterTodos();
        Task<ResponseMessageDefault> Atualizar(PessoaViewModel pessoaViewModel);
        Task<ResponseMessageDefault> Registrar(PessoaViewModel pessoaViewModel);
    }
}
