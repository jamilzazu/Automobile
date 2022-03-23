using Automobile.Core.Mediator;
using Automobile.Proprietarios.API.Application.Commands;
using Automobile.Proprietarios.API.Models;
using Automobile.Proprietarios.API.Models.Enums;
using Automobile.Proprietarios.API.ViewModel;
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
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IMediatorHandler _mediator;
        private readonly ProprietarioModelBuilder _proprietarioModelBuilder;

        public ProprietarioController(IMediatorHandler mediator
            , IProprietarioRepository proprietarioRepository
            , ProprietarioModelBuilder proprietarioModelBuilder)
        {
            _mediator = mediator;
            _proprietarioRepository = proprietarioRepository;
            _proprietarioModelBuilder = proprietarioModelBuilder;
        }

        [HttpGet("lista")]
        public async Task<IEnumerable<ProprietarioViewModel>> Index()
        {
            var proprietarios = _proprietarioModelBuilder.ListaProprietarioViewModel(await _proprietarioRepository.ObterTodos());

            return proprietarios;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProprietarioViewModel>> ProprietarioPorId(Guid id)
        {
            var proprietarios = _proprietarioModelBuilder.CarregaInformacaoProprietario(await _proprietarioRepository.ObterPorId(id));

            return proprietarios;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ProprietarioViewModel>> RegistrarProprietario(ProprietarioViewModel
            viewModel)
        {
            var resultado = await _mediator.EnviarComando(
                  new RegistrarProprietarioCommand(Guid.NewGuid(),
                  viewModel.Nome,
                  viewModel.TipoDocumento,
                  viewModel.Documento,
                  viewModel.Email)
                  );

            return CustomResponse(resultado);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarProprietario(ProprietarioViewModel
            viewModel)
        {
            var resultado = await _mediator.EnviarComando(
                  new AlterarProprietarioCommand((Guid)viewModel.Id,
                  viewModel.Nome,
                  viewModel.TipoDocumento,
                  viewModel.Documento,
                  viewModel.Email)
                  );

            return CustomResponse(resultado);
        }


        [HttpPatch("ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new AtivarProprietarioCommand(id, Cancelado.Nao));

            return CustomResponse(resultado);
        }

        [HttpPatch("cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            var resultado = await _mediator.EnviarComando(new CancelarProprietarioCommand(id, Cancelado.Nao));

            return CustomResponse(resultado);

        }
    }
}