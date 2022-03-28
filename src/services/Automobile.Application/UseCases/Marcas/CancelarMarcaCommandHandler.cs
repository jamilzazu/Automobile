using Automobile.Core.Enums;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Marca;
using Automobile.Domain.Entitites;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Marcass
{
    public class CancelarMarcaCommandHandler : CommandHandler, IRequestHandler<CancelarMarcaCommand, ValidationResult>
    {
        private readonly IMarcaRepository _marcaRepository;

        public CancelarMarcaCommandHandler(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<ValidationResult> Handle(CancelarMarcaCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var marca = await _marcaRepository.ObterMarcaPeloId(message.Id);

            if (marca == null)
            {
                AdicionarErro("Marca não encontrada");
                return ValidationResult;
            }

            if (marca.Cancelado == Cancelado.Sim)
            {
                AdicionarErro($"A marca {marca.Nome} já está cancelado.");
                return ValidationResult;
            }

            CancelarMarca(marca);

            return await PersistirDados(_marcaRepository.UnitOfWork);
        }

        public void CancelarMarca(Marca marca)
        {
            marca.Cancelar();

            _marcaRepository.Atualizar(marca);
        }
    }
}
