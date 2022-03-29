using Automobile.Core.Enums;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities;
using Automobile.Domain.Events.Proprietario;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Veiculos
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
