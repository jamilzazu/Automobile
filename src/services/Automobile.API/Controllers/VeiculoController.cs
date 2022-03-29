using Automobile.Core.Mediator;
using Automobile.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Commands.Veiculo;
using Automobile.Application.Services.Interfaces;
using Automobile.Application.Queries.Request;

namespace Automobile.Veiculos.API.Controllers
{
    [Route("api/veiculo")]
    public class VeiculoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IMediatorHandler mediator, IVeiculoService veiculoService)
        {
            _mediator = mediator;
            _veiculoService = veiculoService;
        }


        [HttpPost("listar")]
        public IActionResult ListarVeiculos([FromBody] FiltroListaVeiculosRequest filtro)
        {
            var resultado = _veiculoService.ListarVeiculos(filtro);

            return CustomResponse(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterVeiculoPeloId(Guid id)
        {
            var resultado = await _veiculoService.ObterVeiculoPeloId(id);

            return CustomResponse(resultado);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarVeiculo(CadastrarVeiculoCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarVeiculo(AtualizarVeiculoCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPatch("indisponibilizar")]
        public async Task<IActionResult> Indisponibilizar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new IndisponibilizarVeiculoCommand(id));

            return CustomResponse(resultado);
        }

        [HttpPatch("vender")]
        public async Task<IActionResult> Vender(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new VenderVeiculoCommand(id));

            return CustomResponse(resultado);
        }
    }
}