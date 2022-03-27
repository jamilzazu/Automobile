using Automobile.Core.Messages;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Events.Proprietario;
using Automobile.Proprietarios.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Handlers.Proprietarios
{
    public class AtivarProprietarioCommandHandler : CommandHandler, IRequestHandler<AtivarProprietarioCommand, ValidationResult>
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public AtivarProprietarioCommandHandler(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(AtivarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = await _proprietarioRepository.ObterProprietarioPeloId(message.Id);

            if (proprietario == null)
            {
                AdicionarErro("Proprietário não encontrado.");
                return ValidationResult;
            }

            if (proprietario.Cancelado == Cancelado.Nao)
            {
                AdicionarErro($"O proprietário {proprietario.Nome} já está ativado.");
                return ValidationResult;
            }

            AtivarProprietario(proprietario, message);

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public void AtivarProprietario(Proprietario proprietario, AtivarProprietarioCommand message)
        {
            proprietario.Ativar();

            _proprietarioRepository.Atualizar(proprietario);

            AdicionarEventoDeAtivarProprietario(proprietario, message);
        }

        public static void AdicionarEventoDeAtivarProprietario(Proprietario proprietario, AtivarProprietarioCommand message)
        {
            proprietario.AdicionarEvento(new ProprietarioCanceladoEvent(message.Id, proprietario.Nome, proprietario.Documento, proprietario.Email.Endereco));
        }
    }
}
