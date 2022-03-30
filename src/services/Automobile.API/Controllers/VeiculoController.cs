using Automobile.Application.Queries.Request;
using Automobile.Application.Services.Interfaces;
using Automobile.Core.Mediator;
using Automobile.Core.Messages.Integration;
using Automobile.Domain.Commands.Veiculo;
using Automobile.MessageBus;
using Automobile.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Automobile.Veiculos.API.Controllers
{
    [Route("api/veiculo")]
    public class VeiculoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IVeiculoService _veiculoService;
        private readonly IMessageBus _bus;

        public VeiculoController(IMediatorHandler mediator, IVeiculoService veiculoService, IMessageBus bus)
        {
            _mediator = mediator;
            _veiculoService = veiculoService;
            _bus = bus;
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

            await CadastrarVeiculos(command);

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

        private async Task<ResponseMessage> CadastrarVeiculos(CadastrarVeiculoCommand veiculo)
        {
            //var _veiculo = await _veiculoService.ObterVeiculoPeloId(veiculo.Id);

            var veiculoCadastrado = new VeiculoCadastradoIntegrationEvent(veiculo.ProprietarioId, veiculo.MarcaId, veiculo.Renavam, veiculo.Quilometragem, veiculo.Valor);

            try
            {
                return await _bus.RequestAsync<VeiculoCadastradoIntegrationEvent, ResponseMessage>(veiculoCadastrado);
            }
            catch
            {
                //await _authenticationService.UserManager.DeleteAsync(usuario);
                throw;
            }

        }
    }
}