using Automobile.Core.Mediator;
using Automobile.Application.Queries.Request;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Commands.Marca;
using Automobile.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Controllers
{
    [Route("api/marca")]
    public class MarcaController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMarcaService _marcaService;

        public MarcaController(IMediatorHandler mediator, IMarcaService marcaService)
        {
            _mediator = mediator;
            _marcaService = marcaService;
        }

        [HttpPost("listar")]
        public IActionResult ListarMarcas([FromBody] FiltroListaMarcasRequest filtro)
        {
            var resultado = _marcaService.ListarMarcas(filtro);

            return CustomResponse(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterMarcaPorId(Guid id)
        {
            var resultado = await _marcaService.ObterMarcaPeloId(id);

            return CustomResponse(resultado);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarMarca(CadastrarMarcaCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPatch("ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new AtivarMarcaCommand(id));

            return CustomResponse(resultado);
        }

        [HttpPatch("cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new CancelarMarcaCommand(id));

            return CustomResponse(resultado);
        }
    }
}