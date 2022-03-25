using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Application.Services.Interfaces;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Automobile.Proprietarios.Domain.Events.Proprietario;
using Automobile.Proprietarios.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Domain.Handlers
{
    public class ProprietarioCommandHandler : CommandHandler, IRequestHandler<CadastrarProprietarioCommand, ValidationResult>
    {
        private readonly IProprietarioQueries _proprietarioQueries;
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioCommandHandler(IProprietarioQueries proprietarioQueries, IProprietarioRepository proprietarioRepository, IProprietarioService proprietarioService)
        {
            _proprietarioQueries = proprietarioQueries;
            _proprietarioRepository = proprietarioRepository;
            _proprietarioService = proprietarioService;
        }

        public async Task<ValidationResult> Handle(CadastrarProprietarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var proprietario = MontaObjetoProprietario(message);

            await ValidaCadastroProprietario(proprietario.Documento);

            CadastrarProprietario(proprietario, message);

            return await PersistirDados(_proprietarioRepository.UnitOfWork);
        }

        public Proprietario MontaObjetoProprietario(CadastrarProprietarioCommand message)
        {
            return new Proprietario(message.Id, message.Nome, message.Documento, message.Email);
        }

        public void CadastrarProprietario(Proprietario proprietario, CadastrarProprietarioCommand message)
        {
            _proprietarioRepository.Adicionar(proprietario);

            AdicionarEventoDeCadastroDoProrprietario(proprietario, message);
        }

        public void AdicionarEventoDeCadastroDoProrprietario(Proprietario proprietario, CadastrarProprietarioCommand message)
        {
            proprietario.AdicionarEvento(new ProprietarioCadastradoEvent(message.Id, message.Nome, message.Documento, message.Email));
        }

        public async Task<ValidationResult> ValidaCadastroProprietario(Documento documento)
        {
            if (await _proprietarioService.ExisteCpfJaCadastrado(documento))
            {
                AdicionarErro("Este Documento já está em uso.");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
