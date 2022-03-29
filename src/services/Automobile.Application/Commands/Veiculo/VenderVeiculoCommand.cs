using Automobile.Application.Validators.Veiculo;
using Automobile.Core.Messages;
using System;

namespace Automobile.Domain.Commands.Proprietario
{
    public class VenderVeiculoCommand : Command
    {
        public Guid Id { get; set; }

        public VenderVeiculoCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new VenderVeiculoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
