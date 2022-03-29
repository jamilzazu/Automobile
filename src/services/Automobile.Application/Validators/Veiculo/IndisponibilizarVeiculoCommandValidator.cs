using Automobile.Domain.Commands.Proprietario;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Veiculo
{
    public class IndisponibilizarVeiculoCommandValidator : AbstractValidator<IndisponibilizarVeiculoCommand>
    {
        public IndisponibilizarVeiculoCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do veículo inválido");
        }
    }
}
