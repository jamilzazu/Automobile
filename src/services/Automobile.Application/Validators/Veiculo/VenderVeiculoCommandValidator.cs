using Automobile.Domain.Commands.Veiculo;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Veiculo
{
    public class VenderVeiculoCommandValidator : AbstractValidator<VenderVeiculoCommand>
    {
        public VenderVeiculoCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do veículo inválido");
        }
    }
}
