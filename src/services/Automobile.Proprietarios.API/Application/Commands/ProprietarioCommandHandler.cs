using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Application.Events;
using Automobile.Proprietarios.API.Models;
using Automobile.Proprietarios.API.Models.Enums;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class ProprietarioCommandHandler : CommandHandler,
        IRequestHandler<RegistrarProprietarioCommand, ValidationResult>,
        IRequestHandler<AlterarProprietarioCommand, ValidationResult>,
        IRequestHandler<CancelarProprietarioCommand, ValidationResult>,
        IRequestHandler<AtivarProprietarioCommand, ValidationResult>
    {

        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioCommandHandler(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = new Proprietario(message.Id, message.Nome, message.TipoDocumento, message.Documento, message.Email);

            var proprietarioExistente = await _proprietarioRepository.ObterPorDocumento(proprietario.Documento.Numero);

            if (proprietarioExistente != null)
            {
                AdicionarErro("Este Documento já está em uso.");
                return ValidationResult;
            }

            _proprietarioRepository.Adicionar(proprietario);

            proprietario.AdicionarEvento(new ProprietarioRegistradoEvent(message.Id, message.Nome, message.TipoDocumento, message.Documento, message.Email));

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = await _proprietarioRepository.ObterPorId(message.Id);

            if (proprietario == null)
            {
                AdicionarErro("Proprietario não encontrado.");
                return ValidationResult;
            }

            if (proprietario != null && proprietario.Documento.Numero != message.Documento)
            {
                AdicionarErro("CPF não pode ser alterado.");
                return ValidationResult;
            }

            proprietario.Alterar(message.Nome, message.Email);

            _proprietarioRepository.Atualizar(proprietario);

            proprietario.AdicionarEvento(new ProprietarioAlteradoEvent(message.Id, message.Nome, message.TipoDocumento, message.Documento, message.Email));

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CancelarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = await _proprietarioRepository.ObterPorId(message.Id);

            if (proprietario.Cancelado == Cancelado.Sim)
            {
                AdicionarErro("Proprietario já está cancelado.");
                return ValidationResult;
            }

            proprietario.Cancelar();

            _proprietarioRepository.Atualizar(proprietario);

            proprietario.AdicionarEvento(new ProprietarioCanceladoEvent(message.Id, message.Status));

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtivarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = await _proprietarioRepository.ObterPorId(message.Id);

            if (proprietario.Cancelado == Cancelado.Nao)
            {
                AdicionarErro("Proprietario já está ativado.");
                return ValidationResult;
            }

            proprietario.Ativar();

            _proprietarioRepository.Atualizar(proprietario);

            proprietario.AdicionarEvento(new ProprietarioAtivadoEvent(message.Id, message.Status));

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }
    }
}
