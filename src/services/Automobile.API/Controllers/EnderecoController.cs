using Automobile.Core.Mediator;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Commands.Endereco;
using Automobile.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Controllers
{
    [Route("api/endereco")]
    public class EnderecoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IMediatorHandler mediator, IEnderecoService enderecoService)
        {
            _mediator = mediator;
            _enderecoService = enderecoService;
        }

        [HttpGet("{proprietarioId}")]
        public async Task<IActionResult> ObterEnderecoPeloProprietarioId(Guid proprietarioId)
        {
            var resultado = await _enderecoService.ObterEnderecoPeloProprietarioId(proprietarioId);

            return CustomResponse(resultado);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarEndereco(CadastrarEnderecoCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarEndereco(AtualizarEnderecoCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPost("consulta-cep")]
        public async Task<IActionResult> ConsultaCEP(CadastrarEnderecoCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }
    }
}