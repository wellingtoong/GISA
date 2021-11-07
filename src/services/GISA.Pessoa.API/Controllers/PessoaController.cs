using AutoMapper;
using GISA.Core.DomainObjects;
using GISA.Pessoa.API.Data.Repository;
using GISA.Pessoa.API.Models;
using GISA.Pessoa.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Controllers
{
    [Route("api/pessoa")]
    public class PessoaController : MainController
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService,
                                IPessoaRepository pessoaRepository,
                                IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Registrar(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!EmailValido(pessoaViewModel.Email)) return CustomResponse();

            var result = await _pessoaRepository.Adicionar(_mapper.Map<Domain.Pessoa>(pessoaViewModel));

            if (!result)
            {
                AdicionarErroProcessamento("Não foi possível registrar a pessoa. Tente novamente!");
                return CustomResponse();
            }

            return CustomResponse();
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
