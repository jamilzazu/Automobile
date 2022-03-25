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
//        private readonly IMediatorHandler _mediator;
//        private readonly IEnderecoRepository _enderecoRepository;
//        private readonly EnderecoModelBuilder _enderecoModelBuilder;


//        public EnderecoController(IMediatorHandler mediator
//            , IEnderecoRepository enderecoRepository
//            , EnderecoModelBuilder enderecoModelBuilder)
//        {
//            _mediator = mediator;
//            _enderecoRepository = enderecoRepository;
//            _enderecoModelBuilder = enderecoModelBuilder;
//        }

//        [HttpGet("{proprietarioId}")]
//        public async Task<EnderecoViewModel> EnderecoPorProprietario(Guid proprietarioId)
//        {

//            var endereco = _enderecoModelBuilder.CarregaInformacaoEndereco(await _enderecoRepository.ObterPorProprietarioId(proprietarioId));

//            return endereco;
//        }

//        [HttpPost("cadastrar")]
//        public async Task<ActionResult<EnderecoViewModel>> RegistrarEndereco(EnderecoViewModel
//            viewModel)
//        {
//            var resultado = await _mediator.EnviarComando(
//                new RegistrarEnderecoCommand(
//                    Guid.NewGuid(),
//                    viewModel.ProprietarioId,
//                    viewModel.Logradouro,
//                    viewModel.Numero,
//                    viewModel.Complemento,
//                    viewModel.Bairro,
//                    viewModel.Cep,
//                    viewModel.Cidade,
//                    viewModel.Estado
//                    )
//                  );

//            return CustomResponse(resultado);
//        }

//        [HttpPut("alterar")]
//        public async Task<ActionResult<EnderecoViewModel>> AlterarEndereco(EnderecoViewModel
//            viewModel)
//        {
//            var resultado = await _mediator.EnviarComando(
//                   new AlterarEnderecoCommand(
//                       viewModel.Id,
//                       viewModel.ProprietarioId,
//                       viewModel.Logradouro,
//                       viewModel.Numero,
//                       viewModel.Complemento,
//                       viewModel.Bairro,
//                       viewModel.Cep,
//                       viewModel.Cidade,
//                       viewModel.Estado
//                       )
//                     );

//            return CustomResponse(resultado);
//        }
//    }
//}