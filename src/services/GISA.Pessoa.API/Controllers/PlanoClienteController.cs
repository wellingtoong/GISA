using AutoMapper;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.Pessoa.API.Service;
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

        public PlanoClienteController(IPlanoClienteService planoClienteService,
            IPlanoClienteRepository planoClienteRepository,
            IPlanoRepository planoRepository,
            IMapper mapper)
        {
            _planoClienteService = planoClienteService;
            _planoClienteRepository = planoClienteRepository;
            _planoRepository = planoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("planos-clientes")]
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
        [Route("plano-cliente/{id:guid}")]
        public async Task<IActionResult> ObterPessoaPorId(Guid id)
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
        [Route("plano-cliente/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, PlanoClienteViewModel planoClienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await ValidaCliente(planoClienteViewModel);
            await ValidaPlano(planoClienteViewModel);

            if (!OperacaoValida()) return CustomResponse();

            var planoCliente = _mapper.Map<Domain.PlanoCliente>(planoClienteViewModel);

            var result = await _planoClienteService.Atualizar(id, planoCliente);

            if (!result)
            {
                AdicionarErroProcessamento("Não foi possível atualizar o plano cliente. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
        }

        [HttpPost]
        [Route("registrar")]
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

            CalcularValorAcrescimo(planoClienteViewModel, plano.Valor);
            CalcularValorDesconto(planoClienteViewModel, plano.Valor);

            return CustomResponse();

            var result = await _planoClienteRepository.Adicionar(_mapper.Map<Domain.PlanoCliente>(planoClienteViewModel));

            if (!result)
            {
                AdicionarErroProcessamento("Não foi possível registrar o plano 2wcliente. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
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

        private void CalcularValorAcrescimo(PlanoClienteViewModel plano, decimal valor)
        {
            decimal acrescimo = 0;
            decimal porcentagem = 0;
            decimal valorFinal = plano.ValorFinal;

            if (plano.Acrescimo.HasValue)
            {
                porcentagem = plano.Acrescimo.Value / 100;
                acrescimo = valor * porcentagem;
            }

            decimal total = (valor + acrescimo) + valorFinal;
            plano.ValorFinal = valorFinal < 0 ? 0 : total;
        }

        private void CalcularValorDesconto(PlanoClienteViewModel plano, decimal valor)
        {
            decimal desconto = 0;
            decimal porcentagem = 0;
            decimal valorFinal = plano.ValorFinal;

            if (plano.Desconto.HasValue)
            {
                porcentagem = (valor * plano.Desconto.Value) / 100;
                desconto = valor -= porcentagem;
            }

            decimal total = (valor - desconto) + valorFinal;
            decimal dif = valorFinal - total;
            plano.ValorFinal = valorFinal < 0 ? 0 : (total + dif);
        }
    }
}
