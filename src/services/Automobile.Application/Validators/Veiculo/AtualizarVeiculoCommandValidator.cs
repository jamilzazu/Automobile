using Automobile.Domain.Commands.Veiculo;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Veiculo
{
    public class AtualizarVeiculoCommandValidator : AbstractValidator<AtualizarVeiculoCommand>
    {
        public AtualizarVeiculoCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do veículo inválido");

            RuleFor(c => c.Renavam)
                .NotEmpty()
                .WithMessage("O renavam do veículo não foi informado");

            RuleFor(c => c.Quilometragem)
                .NotEmpty()
                .WithMessage("a quilometragem do veículo não foi informado");

            RuleFor(c => c.Modelo.Descricao)
                .NotEmpty()
                .WithMessage("O modelo do veículo não foi informado");

            RuleFor(c => c.Modelo.AnoModelo)
                .NotEmpty()
                .WithMessage("O ano do modelo do veículo não foi informado");

            RuleFor(c => c.Modelo.AnoFabricacao)
                .NotEmpty()
                .WithMessage("O ano de fabricação do veículo não foi informado");

            RuleFor(c => c.Valor)
                .NotEmpty()
                .WithMessage("O valor do veículo não foi informado");
        }
    }
}
