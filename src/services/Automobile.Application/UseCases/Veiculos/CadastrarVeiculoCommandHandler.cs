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
    public class CadastrarVeiculoCommandHandler : CommandHandler, IRequestHandler<CadastrarVeiculoCommand, ValidationResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public CadastrarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarVeiculoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            if (RenavamEstaVinculadoAOutroVeiculo(message.Renavam))
            {
                AdicionarErro($"Este renavam {message.Renavam} já está em uso.");
                return ValidationResult;
            }

            var veiculo = MontaObjetoVeiculo(message);

            _veiculoRepository.Adicionar(veiculo);

            return await PersistirDados(_veiculoRepository.UnitOfWork);
        }

        public bool RenavamEstaVinculadoAOutroVeiculo(string renavam)
        {
            var renavamEstaVinculadoAOutroVeiculo = _veiculoRepository.ObterVeiculoPeloNumeroRenavam(renavam);

            return renavamEstaVinculadoAOutroVeiculo.Result != null;
        }

        public static Veiculo MontaObjetoVeiculo(CadastrarVeiculoCommand message)
        {
            return new Veiculo(message.Id, message.ProprietarioId, message.MarcaId, message.Modelo, message.Renavam, message.Quilometragem, message.Valor, FluxoRevenda.Disponivel);
        }


        public void CadastrarVeiculo(Veiculo veiculo)
        {
            _veiculoRepository.Adicionar(veiculo);

            AdicionarEventoDeCadastroDoVeiculo(veiculo);
        }

        public static void AdicionarEventoDeCadastroDoVeiculo(Veiculo veiculo)
        {
            veiculo.AdicionarEvento(new VeiculoCadastradoEvent(veiculo.Renavam, veiculo.Modelo, veiculo.Quilometragem, veiculo.Valor));
        }
    }
}
