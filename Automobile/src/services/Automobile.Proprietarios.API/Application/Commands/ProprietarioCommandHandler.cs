using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Application.Events;
using Automobile.Proprietarios.API.Models;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class ProprietarioCommandHandler : CommandHandler, IRequestHandler<RegistrarProprietarioCommand, ValidationResult>
    {

        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioCommandHandler(IProprietarioRepository proprietarioRepository)
        {
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = new Proprietario(message.Id, message.Nome, message.Email, message.Cpf, message.Endereco);

            var proprietarioExistente = await _proprietarioRepository.ObterPorCpf(proprietario.Cpf.Numero);

            if (proprietarioExistente != null)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            _proprietarioRepository.Adicionar(proprietario);

            proprietario.AdicionarEvento(new ProprietarioRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf, message.Endereco));

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }
    }
}
