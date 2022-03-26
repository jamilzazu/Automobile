using Automobile.Core.Messages;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Automobile.Proprietarios.Domain.Events.Proprietario;
using Automobile.Proprietarios.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Handlers
{
    public class AlterarProprietarioCommandHandler : CommandHandler, IRequestHandler<AtualizarProprietarioCommand, ValidationResult>
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public AlterarProprietarioCommandHandler(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(AtualizarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = await _proprietarioRepository.ObterProprietarioPeloId(message.Id);

            if (proprietario == null)
            {
                AdicionarErro("Proprietario não encontrado.");
                return ValidationResult;
            }

            if (DocumentoEstaVinculadoAOutroProprietario(proprietario.Documento, message.Documento))
            {
                AdicionarErro($"Este {message.Documento.TipoDocumentoDescricao()} já está em uso.");
                return ValidationResult;
            }

            AtualizarProprietario(proprietario, message);

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }


        public bool DocumentoEstaVinculadoAOutroProprietario(Documento documentoProprietario, Documento documentoCommand)
        {
            if (documentoProprietario.NumeroDocumento != documentoCommand.NumeroDocumento)
            {
                var documentoVinculadoAOutroProrprietario = _proprietarioRepository.ObterProprietarioPeloNumeroDocumento(documentoCommand);

                return documentoVinculadoAOutroProrprietario.Result != null;
            }

            return false;
        }

        public void AtualizarProprietario(Proprietario proprietario, AtualizarProprietarioCommand message)
        {
            proprietario.Atualizar(message.Nome, message.Documento, message.Email);

            _proprietarioRepository.Atualizar(proprietario);

            AdicionarEventoDeAtualizacaoDoProrprietario(proprietario, message);
        }

        public void AdicionarEventoDeAtualizacaoDoProrprietario(Proprietario proprietario, AtualizarProprietarioCommand message)
        {
            proprietario.AdicionarEvento(new ProprietarioAtualizadoEvent(message.Id, message.Nome, message.Documento, message.Email));
        }
    }
}
