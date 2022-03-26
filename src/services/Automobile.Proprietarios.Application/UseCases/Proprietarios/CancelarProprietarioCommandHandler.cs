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

namespace Automobile.Proprietarios.Domain.Handlers.Proprietarioss
{
    public class CancelarProprietarioCommandHandler : CommandHandler, IRequestHandler<CancelarProprietarioCommand, ValidationResult>
    {
        private readonly IProprietarioRepository _proprietarioRepository;

        public CancelarProprietarioCommandHandler(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(CancelarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = await _proprietarioRepository.ObterProprietarioPeloId(message.Id);

            if (proprietario == null)
            {
                AdicionarErro("Proprietário não encontrado.");
                return ValidationResult;
            }

            if (proprietario.Cancelado == Cancelado.Sim)
            {
                AdicionarErro($"O proprietário {proprietario.Nome} já está cancelado.");
                return ValidationResult;
            }

            CancelarProprietario(proprietario, message);

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public void CancelarProprietario(Proprietario proprietario, CancelarProprietarioCommand message)
        {
            proprietario.Cancelar();

            _proprietarioRepository.Atualizar(proprietario);

            AdicionarEventoDeCancelarProprietario(proprietario, message);
        }

        public void AdicionarEventoDeCancelarProprietario(Proprietario proprietario, CancelarProprietarioCommand message)
        {
            proprietario.AdicionarEvento(new ProprietarioCanceladoEvent(message.Id, proprietario.Nome, proprietario.Documento, proprietario.Email.Endereco));
        }
    }
}
