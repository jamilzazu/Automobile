using Automobile.Core.Enums;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Marca;
using Automobile.Domain.Entitites;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Proprietarios
{
    public class AtivarMarcaCommandHandler : CommandHandler, IRequestHandler<AtivarMarcaCommand, ValidationResult>
    {
        private readonly IMarcaRepository _marcaRepository;

        public AtivarMarcaCommandHandler(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<ValidationResult> Handle(AtivarMarcaCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var marca = await _marcaRepository.ObterMarcaPeloId(message.Id);

            if (marca == null)
            {
                AdicionarErro("Marca não encontrada.");
                return ValidationResult;
            }

            if (marca.Cancelado == Cancelado.Sim)
            {
                AdicionarErro($"A marca {marca.Nome} já está ativada.");
                return ValidationResult;
            }

            AtivarMarca(marca);

            return await PersistirDados(_marcaRepository.UnitOfWork);
        }

        public void AtivarMarca(Marca marca)
        {
            marca.Ativar();

            _marcaRepository.Atualizar(marca);
        }
    }
}
