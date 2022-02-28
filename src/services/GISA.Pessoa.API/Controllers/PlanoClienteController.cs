﻿using AutoMapper;
using GISA.Core.Communication;
using GISA.MessageBus;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.Pessoa.API.Service;
using GISA.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Controllers
{
    [Route("api/plano-cliente")]
    public class PlanoClienteController : MainController
    {
        private readonly IPlanoClienteService _planoClienteService;
        private readonly IPlanoClienteRepository _planoClienteRepository;
        private readonly IPlanoRepository _planoRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBus _bus;

        public PlanoClienteController(IPlanoClienteService planoClienteService,
            IPlanoClienteRepository planoClienteRepository,
            IPlanoRepository planoRepository,
            IMapper mapper,
            IMessageBus bus)
        {
            _planoClienteService = planoClienteService;
            _planoClienteRepository = planoClienteRepository;
            _planoRepository = planoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("obter-planos-clientes")]
        public async Task<IActionResult> ObterTodos()
        {
            var planoCliente = _mapper.Map<IEnumerable<PlanoClienteViewModel>>(await _planoClienteRepository.ObterTodos());

            if (planoCliente == null)
            {
                AdicionarErroProcessamento("Não foi possível listar os planos clientes. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(planoCliente);
        }

        [HttpGet]
        [Route("obter-plano-cliente-pessoa/{id:guid}")]
        public async Task<IActionResult> ObterPlanoPessoaPorPessoaId(Guid id)
        {
            var planoCliente = _mapper.Map<PlanoClienteViewModel>(await _planoClienteRepository.ObterPlanoClientePorPessoaId(id));

            if (planoCliente == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o plano cliente. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(planoCliente);
        }

        [HttpGet]
        [Route("obter-plano-cliente/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var planoCliente = _mapper.Map<PlanoClienteViewModel>(await _planoClienteRepository.ObterPorId(id));

            if (planoCliente == null)
            {
                AdicionarErroProcessamento("Não foi possível obter o plano cliente. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse(planoCliente);
        }

        [HttpPut]
        [Route("atualizar-plano-cliente")]
        public async Task<IActionResult> Atualizar(Guid id, PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await ValidaCliente(planoClienteViewModel);
            await ValidaPlano(planoClienteViewModel);

            if (!OperacaoValida()) return CustomResponse();

            var result = await _bus.RequestAsync<Domain.PlanoCliente, ResponseResult>(_mapper.Map<Domain.PlanoCliente>(planoClienteViewModel));

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }

        [HttpPost]
        [Route("novo-registro")]
        public async Task<IActionResult> Registrar(PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await ValidaCliente(planoClienteViewModel);
            await ValidaPlano(planoClienteViewModel);

            if (!OperacaoValida()) return CustomResponse();

            var plano = await _planoRepository.ObterPorId(planoClienteViewModel.PlanoId);

            if (plano == null)
            {
                AdicionarErroProcessamento("Não é possível obter o plano cliente. Tente novamente!");
                return CustomResponse();
            }

            CalcularValorDesconto(planoClienteViewModel, plano.Valor);

            var result = await _bus.RequestAsync<Domain.PlanoCliente, ResponseResult>(_mapper.Map<Domain.PlanoCliente>(planoClienteViewModel));

            if (!OperacaoValida()) return CustomResponse(result);

            return CustomResponse(result);
        }

        private async Task ValidaCliente(PlanoClienteViewModel planoClienteViewModel)
        {
            var clienteAtivo = await _planoClienteRepository.PessoaAtivo(planoClienteViewModel.PessoaId);

            if (!clienteAtivo)
            {
                AdicionarErroProcessamento("Não é possível registrar para um cliente Inativo. Tente novamente!");
            }
        }

        private async Task ValidaPlano(PlanoClienteViewModel planoClienteViewModel)
        {
            var planoAtivo = await _planoClienteRepository.PlanoAtivo(planoClienteViewModel.PlanoId);

            if (!planoAtivo)
            {
                AdicionarErroProcessamento("Não é possível registrar para um plano Inativo. Tente novamente!");
            }
        }

        private void CalcularValorDesconto(PlanoClienteViewModel plano, decimal valor)
        {
            if (plano.Desconto.HasValue)
            {
                decimal desconto = (valor * plano.Desconto.Value) / 100;
                var valorFinal = valor - desconto;
                plano.ValorFinal = valorFinal > 0 ? valorFinal : 0;
            }
        }
    }
}
