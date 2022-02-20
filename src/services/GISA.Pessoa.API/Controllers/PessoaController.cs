﻿using AutoMapper;
using GISA.Core.DomainObjects;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.Pessoa.API.Service;
using GISA.Core.Messages.Integration;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Controllers
{
    [Route("api/pessoa")]
    public class PessoaController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;

        public PessoaController(IPessoaService pessoaService,
                                IPessoaRepository pessoaRepository,
                                IMapper mapper,
                                IMessageBus bus)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("total-pessoa")]
        public async Task<IActionResult> ObterTotalUsuario()
        {
            var pessoa = await _pessoaRepository.ObterTotalUsuario();

            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obnter o total pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("total-pessoa-ativo")]
        public async Task<IActionResult> ObterTotalUsuarioAtivo()
        {
            var pessoa = await _pessoaRepository.ObterTotalUsuarioAtivo();

            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obnter o total pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("total-pessoa-inativo")]
        public async Task<IActionResult> ObterTotalUsuarioInativo()
        {
            var pessoa = await _pessoaRepository.ObterTotalUsuarioInativo();

            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obnter o total pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("obter-pessoas")]
        public async Task<IActionResult> ObterTodos()
        {
            var pessoa = _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterTodasPessoasEndereco());
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível listar as pessoas. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("obter-pessoa/{id:guid}")]
        public async Task<IActionResult> ObterPessoaPorId(Guid id)
        {
            var pessoa = _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPessoaEnderecoPorId(id));

            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obter a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpGet]
        [Route("obter-pessoa/{email}")]
        public async Task<IActionResult> ObterPessoaPorEmail(string email)
        {
            if (!EmailValido(email)) return CustomResponse();

            var pessoa = _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterPessoaPorEmail(email));

            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível obter a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(pessoa);
        }

        [HttpPut]
        [Route("atualizar-pessoa")]
        public async Task<IActionResult> Atualizar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(pessoaViewModel.Email)) return CustomResponse();

            var result = await _bus.RequestAsync<Domain.Pessoa, ResponseMessageDefault>(_mapper.Map<Domain.Pessoa>(pessoaViewModel));

            if (!result.Sucess)
            {
                AdicionarErroProcessamento("Não foi possível atualizar a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(result);
        }

        [HttpPost]
        [Route("novo-registro")]
        public async Task<IActionResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(pessoaViewModel.Email)) return CustomResponse();

            var result = await _bus.RequestAsync<Domain.Pessoa, ResponseMessageDefault>(_mapper.Map<Domain.Pessoa>(pessoaViewModel));

            if (!result.Sucess)
            {
                AdicionarErroProcessamento("Não foi possível registrar a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(result);
        }

        private bool EmailValido(string email)
        {
            try
            {
                var result = new Email(email);
                if (!String.IsNullOrWhiteSpace(result.Endereco)) return true;
            }
            catch (DomainException)
            {
                AdicionarErroProcessamento("Endereço de e-mail inválido.");
                return false;
            }

            return false;
        }
    }
}
