using Automobile.Core.Mediator;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Controllers
{
    [Route("api/proprietario")]
    public class ProprietarioController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IProprietarioQueries _proprietarioQueries;

        public ProprietarioController(IMediatorHandler mediator, IProprietarioQueries proprietarioQueries)
        {
            _mediator = mediator;
            _proprietarioQueries = proprietarioQueries;
        }

        //[HttpGet("lista")]
        //public IEnumerable<IActionResult> Index()
        //{
        //    var proprietarios = _proprietarioModelBuilder.ListaProprietarioViewModel(_proprietarioRepository.ObterTodos());

        //    return proprietarios;
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> ProprietarioPorId(Guid id)
        {
            var resultado = await _proprietarioQueries.ObterProprietarioPorId(id);

            return CustomResponse(resultado);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarProprietario(CadastrarProprietarioCommand command)
        {
            var resultado = await _mediator.EnviarComando(command);

            return CustomResponse(resultado);
        }

        //[HttpPut("alterar")]
        //public async Task<ActionResult<ProprietarioViewModel>> AlterarProprietario(ProprietarioViewModel view)
        //{
        //    var resultado = await _mediator.EnviarComando(new AlterarProprietarioCommand(view.Id, view.Nome, view.Documento, view.Email));

        //    return CustomResponse(resultado);
        //}


        //[HttpPatch("ativar")]
        //public async Task<ActionResult<ProprietarioViewModel>> Ativar(Guid id)
        //{
        //    var resultado = await _mediator.EnviarComando(new AtivarProprietarioCommand(id));

        //    return CustomResponse(resultado);
        //}


        //[HttpPatch("cancelar")]
        //public async Task<ActionResult<ProprietarioViewModel>> Cancelar(Guid id)
        //{
        //    var resultado = await _mediator.EnviarComando(new CancelarProprietarioCommand(id));

        //    return CustomResponse(resultado);

        //}
    }
}