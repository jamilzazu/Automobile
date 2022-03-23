//using Automobile.Core.Mediator;
//using Automobile.Proprietarios.API.Application.Commands;
//using Automobile.Proprietarios.API.Models;
//using Automobile.Proprietarios.API.ViewModel;
//using Automobile.WebAPI.Core.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;

//namespace Automobile.Enderecos.API.Controllers
//{
//    [Route("api/proprietario-endereco")]
//    public class EnderecoController : MainController
//    {
//        private readonly IEnderecoRepository _enderecoRepository;
//        private readonly IMediatorHandler _mediator;

//        public EnderecoController(IEnderecoRepository enderecoRepository, IMediatorHandler mediator)
//        {
//            _enderecoRepository = enderecoRepository;
//            _mediator = mediator;
//        }

//        [HttpGet("{proprietarioId}")]
//        public async Task<Endereco> EnderecoPorProprietario(Guid proprietarioId)
//        {
//            return await _enderecoRepository.ObterPorId(proprietarioId);
//        }

//        [HttpPost("cadastro")]
//        public async Task<IActionResult> RegistrarEndereco(EnderecoViewModel
//            view)
//        {
//            Guid enderecoId = Guid.NewGuid();
//            //Guid enderecoId = Guid.NewGuid();

//            //var endereco = new Endereco(enderecoId,
//            //    view.Endereco.Logradouro,
//            //    view.Endereco.Numero,
//            //    view.Endereco.Complemento,
//            //    view.Endereco.Bairro,
//            //    view.Endereco.Cep,
//            //    view.Endereco.Cidade,
//            //    view.Endereco.Estado,
//            //    enderecoId);

//            var resultado = await _mediator.EnviarComando(
//                  new RegistrarEnderecoCommand(enderecoId,
//                  view.Nome,
//                  view.Cpf,
//                  view.Email)
//                  );

//            return CustomResponse(resultado);
//        }

//        [HttpPut("alterar")]
//        public async Task<IActionResult> AlterarEndereco(EnderecoViewModel
//            view)
//        {
//            //var endereco = new Endereco(view.Endereco.Id,
//            //    view.Endereco.Logradouro,
//            //    view.Endereco.Numero,
//            //    view.Endereco.Complemento,
//            //    view.Endereco.Bairro,
//            //    view.Endereco.Cep,
//            //    view.Endereco.Cidade,
//            //    view.Endereco.Estado,
//            //    view.Id);

//            var resultado = await _mediator.EnviarComando(
//                  new AlterarEnderecoCommand(view.Id,
//                  view.Nome,
//                  view.Cpf,
//                  view.Email)
//                  );

//            return CustomResponse(resultado);
//        }
//    }
//}