//using Automobile.Core.Messages;
//using Automobile.Proprietarios.Application.Queries.Interfaces;
//using Automobile.Proprietarios.Domain.Commands.Proprietario;
//using Automobile.Proprietarios.Domain.Entities;
//using Automobile.Proprietarios.Domain.Repositories;
//using FluentValidation.Results;
//using MediatR;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Automobile.Proprietarios.Domain.Handlers
//{
//    public class CadastrarProprietarioCommandHandler : CommandHandler, IRequestHandler<CadastrarProprietarioCommand, ValidationResult>
//    {
//        private readonly IProprietarioQueries _proprietarioQueries;
//        private readonly IProprietarioRepository _proprietarioRepository;

//        public CadastrarProprietarioCommandHandler(IProprietarioQueries proprietarioQueries, IProprietarioRepository proprietarioRepository)
//        {
//            _proprietarioQueries = proprietarioQueries;
//            _proprietarioRepository = proprietarioRepository;
//        }

//        public async Task<ValidationResult> Handle(CadastrarProprietarioCommand message, CancellationToken cancellationToken)
//        {
//            if (!message.EhValido()) return message.ValidationResult;

//            var proprietario = new Proprietario(message.Id, message.Nome, message.Documento, message.Email);

//            var cpfJaCadastrado = await _proprietarioQueries.ObterProprietarioPeloNumeroDocumento(proprietario.Documento);

//            if (cpfJaCadastrado != null)
//            {
//                AdicionarErro("Este Documento já está em uso.");
//                return ValidationResult;
//            }

//            _proprietarioRepository.Adicionar(proprietario);

//            //proprietario.AdicionarEvento(new ProprietarioRegistradoEvent(message.Id, message.Nome, message.TipoDocumento, message.Documento, message.Email));

//            return await PersistirDados(_proprietarioRepository.UnitOfWork);
//        }

//        //public async Task<ValidationResult> Handle(AlterarProprietarioCommand message, CancellationToken cancellationToken)
//        //{
//        //    if (!message.EhValido()) return message.ValidationResult;

//        //    var proprietario = await _proprietarioRepository.ObterPorId(message.Id);

//        //    if (proprietario == null)
//        //    {
//        //        AdicionarErro("Proprietario não encontrado.");
//        //        return ValidationResult;
//        //    }

//        //    if (proprietario.Documento.NumeroDocumento != message.Documento.NumeroDocumento)
//        //    {
//        //        var documentoExistente = await _proprietarioRepository.ObterPorDocumento(message.Documento.NumeroDocumento);

//        //        if (documentoExistente != null)
//        //        {
//        //            AdicionarErro("Este Documento já está em uso.");
//        //            return ValidationResult;
//        //        }
//        //    }

//        //    proprietario.Alterar(message.Nome, message.Email);

//        //    _proprietarioRepository.Atualizar(proprietario);

//        //    //proprietario.AdicionarEvento(new ProprietarioAlteradoEvent(message.Id, message.Nome, message.TipoDocumento, message.Documento, message.Email));

//        //    return await PersistirDados(_proprietarioRepository.UnitOfWork);
//        //}

//        //public async Task<ValidationResult> Handle(CancelarProprietarioCommand message, CancellationToken cancellationToken)
//        //{
//        //    if (!message.EhValido()) return message.ValidationResult;

//        //    var proprietario = await _proprietarioRepository.ObterPorId(message.Id);

//        //    if (proprietario == null)
//        //    {
//        //        AdicionarErro("Proprietario não encontrado.");
//        //        return ValidationResult;
//        //    }

//        //    if (proprietario.Cancelado == Cancelado.Sim)
//        //    {
//        //        AdicionarErro("Proprietario já está cancelado.");
//        //        return ValidationResult;
//        //    }

//        //    proprietario.Cancelar();

//        //    _proprietarioRepository.Atualizar(proprietario);

//        //    //proprietario.AdicionarEvento(new ProprietarioCanceladoEvent(message.Id, Cancelado.Sim));

//        //    return await PersistirDados(_proprietarioRepository.UnitOfWork);
//        //}

//        //public async Task<ValidationResult> Handle(AtivarProprietarioCommand message, CancellationToken cancellationToken)
//        //{
//        //    if (!message.EhValido()) return message.ValidationResult;

//        //    var proprietario = await _proprietarioRepository.ObterPorId(message.Id);

//        //    if (proprietario == null)
//        //    {
//        //        AdicionarErro("Proprietario não encontrado.");
//        //        return ValidationResult;
//        //    }

//        //    if (proprietario.Cancelado == Cancelado.Nao)
//        //    {
//        //        AdicionarErro("Proprietario já está ativado.");
//        //        return ValidationResult;
//        //    }

//        //    proprietario.Ativar();

//        //    _proprietarioRepository.Atualizar(proprietario);

//        //    //proprietario.AdicionarEvento(new ProprietarioAtivadoEvent(message.Id, Cancelado.Nao));

//        //    return await PersistirDados(_proprietarioRepository.UnitOfWork);
//        //}
//    }
//}
