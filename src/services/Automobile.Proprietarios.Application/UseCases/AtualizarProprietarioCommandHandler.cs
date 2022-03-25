using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Handlers
{
    public class AtualizarProprietarioCommandHandler : CommandHandler, IRequestHandler<AtualizarProprietarioCommand, ValidationResult>
    {
        private readonly IProprietarioQueries _proprietarioQueries;
        private readonly IProprietarioRepository _proprietarioRepository;

        public AtualizarProprietarioCommandHandler(IProprietarioRepository proprietarioRepository)
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

            if (proprietario.Documento.NumeroDocumento != message.Documento.NumeroDocumento)
            {
                var cpfJaCadastrado = await _proprietarioQueries.ObterProprietarioPeloNumeroDocumento(proprietario.Documento);

                if (cpfJaCadastrado != null)
                {
                    AdicionarErro("Este Documento já está em uso.");
                    return ValidationResult;
                }
            }

            proprietario.Alterar(message.Nome, message.Documento, message.Email);

            _proprietarioRepository.Atualizar(proprietario);

            //proprietario.AdicionarEvento(new ProprietarioRegistradoEvent(message.Id, message.Nome, message.TipoDocumento, message.Documento, message.Email));

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }
    }
}
