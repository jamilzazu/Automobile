using Automobile.Core.Enums;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Objects;
using Automobile.Domain.Events.Proprietario;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Veiculos
{
    public class CadastrarVeiculoCommandHandler : CommandHandler, IRequestHandler<CadastrarProprietarioCommand, ValidationResult>
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public CadastrarVeiculoCommandHandler(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            if (DocumentoEstaVinculadoAOutroProprietario(message.Documento))
            {
                AdicionarErro($"Este {message.Documento.TipoDocumentoDescricao()} já está em uso.");
                return ValidationResult;
            }

            var proprietario = MontaObjetoProprietario(message);

            _proprietarioRepository.Adicionar(proprietario);

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public static Proprietario MontaObjetoProprietario(CadastrarProprietarioCommand message)
        {
            return new Proprietario(message.Id, message.Nome, message.Documento, message.Email,Cancelado.Nao);
        }

        public bool DocumentoEstaVinculadoAOutroProprietario(Documento numeroDocumento)
        {
            var documentoVinculadoAOutroProprietario = _proprietarioRepository.ObterProprietarioPeloNumeroDocumento(numeroDocumento);

            return documentoVinculadoAOutroProprietario.Result != null;
        }

        public void CadastrarProprietario(Proprietario proprietario, CadastrarProprietarioCommand message)
        {
            _proprietarioRepository.Adicionar(proprietario);

            AdicionarEventoDeCadastroDoProprietario(proprietario, message);
        }

        public static void AdicionarEventoDeCadastroDoProprietario(Proprietario proprietario, CadastrarProprietarioCommand message)
        {
            proprietario.AdicionarEvento(new ProprietarioCadastradoEvent(message.Id, message.Nome, message.Documento, message.Email));
        }
    }
}
