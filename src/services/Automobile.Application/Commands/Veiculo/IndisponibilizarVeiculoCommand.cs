using Automobile.Application.Validators.Veiculo;
using Automobile.Core.Messages;
using System;

namespace Automobile.Domain.Commands.Proprietario
{
    public class IndisponibilizarVeiculoCommand : Command
    {
        public Guid Id { get; set; }

        public IndisponibilizarVeiculoCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new IndisponibilizarVeiculoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
