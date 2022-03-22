using Automobile.Core.Mediator;
using Automobile.Proprietarios.API.Application.Commands;
using Automobile.Proprietarios.API.Models;
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

        public ProprietarioController(IProprietarioRepository proprietarioRepository, IMediatorHandler mediator)
        {
            _proprietarioRepository = proprietarioRepository;
            _mediator = mediator;
        }

        [HttpGet("lista")]
        public async Task<IEnumerable<Proprietario>> Index()
        {
            return await _proprietarioRepository.ObterTodos();
        }

        [HttpGet("{id}")]
        public async Task<Proprietario> ProprietarioPorId(Guid id)
        {
            return await _proprietarioRepository.ObterPorId(id);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<Proprietario> ProprietarioPorCpf(string cpf)
        {
            return await _proprietarioRepository.ObterPorCpf(cpf);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> RegistrarProprietario(ProprietarioViewModel
            view)
        {

            var resultado = await _mediator.EnviarComando(
                 new RegistrarProprietarioCommand(view.Id,
                 view.Nome,
                 view.Cpf,
                 view.Email)
                 );

            return CustomResponse(resultado);
        }
    }
}