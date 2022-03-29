using Automobile.Application.Events.Veiculo;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Commands.Veiculo;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Enums;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Veiculos
{
    public class IndisponibilizarVeiculoCommandHandler : CommandHandler, IRequestHandler<IndisponibilizarVeiculoCommand, ValidationResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public IndisponibilizarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<ValidationResult> Handle(IndisponibilizarVeiculoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var veiculo = await _veiculoRepository.ObterVeiculoPeloId(message.Id);

            if (veiculo == null)
            {
                AdicionarErro("Veículo não encontrado.");
                return ValidationResult;
            }

            if (veiculo.Status == FluxoRevenda.Indisponivel)
            {
                AdicionarErro($"O veículo com renavam {veiculo.Renavam} já está indisponivel.");
                return ValidationResult;
            }

            IndisponibilizarVeiculo(veiculo, message);

            return await PersistirDados(_veiculoRepository.UnitOfWork);
        }

        public void IndisponibilizarVeiculo(Veiculo veiculo, IndisponibilizarVeiculoCommand message)
        {
            veiculo.Indisponibilizar();

            _veiculoRepository.Atualizar(veiculo);

            AdicionarEventoDeIndisponibilizarVeiculo(veiculo, message);
        }

        public static void AdicionarEventoDeIndisponibilizarVeiculo(Veiculo veiculo, IndisponibilizarVeiculoCommand message)
        {
            veiculo.AdicionarEvento(new VeiculoIndisponibilizadoEvent(message.Id, veiculo.Renavam, veiculo.Modelo, veiculo.Quilometragem, veiculo.Valor));
        }
    }
}
