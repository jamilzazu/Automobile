using Automobile.Core.Mediator;
using Automobile.Application.Queries.Request;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Commands.Proprietario;
using Automobile.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Controllers
{
    [Route("api/proprietario")]
    public class ProprietarioController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IMediatorHandler mediator, IProprietarioService proprietarioService)
        {
            _mediator = mediator;
            _proprietarioService = proprietarioService;
        }

        [HttpPost("listar")]
        public IActionResult ListarProprietarios([FromBody] FiltroListaProprietariosRequest filtro)
        {
            var resultado = _proprietarioService.ListarProprietarios(filtro);

            return CustomResponse(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProprietarioPorId(Guid id)
        {
            var resultado = await _proprietarioService.ObterProprietarioPeloId(id);

            return CustomResponse(resultado);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarProprietario(CadastrarProprietarioCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarProprietario(AtualizarProprietarioCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        [HttpPatch("ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new AtivarProprietarioCommand(id));

            return CustomResponse(resultado);
        }

        [HttpPatch("cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new CancelarProprietarioCommand(id));

            return CustomResponse(resultado);
        }
    }
}