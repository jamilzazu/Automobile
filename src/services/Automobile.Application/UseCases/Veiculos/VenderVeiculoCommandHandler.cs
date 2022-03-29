using Automobile.Application.Events.Veiculo;
using Automobile.Core.Messages;
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
    public class VenderVeiculoCommandHandler : CommandHandler, IRequestHandler<VenderVeiculoCommand, ValidationResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VenderVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<ValidationResult> Handle(VenderVeiculoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var veiculo = await _veiculoRepository.ObterVeiculoPeloId(message.Id);

            if (veiculo == null)
            {
                AdicionarErro("Veículo não encontrado.");
                return ValidationResult;
            }

            if (veiculo.Status == FluxoRevenda.Vendido)
            {
                AdicionarErro($"O veículo com renavam {veiculo.Renavam} já está vendido.");
                return ValidationResult;
            }

            VenderVeiculo(veiculo, message);

            return await PersistirDados(_veiculoRepository.UnitOfWork);
        }

        public void VenderVeiculo(Veiculo veiculo, VenderVeiculoCommand message)
        {
            veiculo.Vender();

            _veiculoRepository.Atualizar(veiculo);

            AdicionarEventoDeVenderVeiculo(veiculo, message);
        }

        public static void AdicionarEventoDeVenderVeiculo(Veiculo veiculo, VenderVeiculoCommand message)
        {
            veiculo.AdicionarEvento(new VeiculoIndisponibilizadoEvent(message.Id, veiculo.Renavam, veiculo.Modelo, veiculo.Quilometragem, veiculo.Valor));
        }
    }
}
