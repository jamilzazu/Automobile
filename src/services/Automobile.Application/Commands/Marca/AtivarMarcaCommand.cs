using Automobile.Application.Validators.Proprietario;
using Automobile.Core.Messages;
using System;

namespace Automobile.Domain.Commands.Marca
{
    public class AtivarMarcaCommand : Command
    {
        public Guid Id { get; set; }

        public AtivarMarcaCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtivarMarcaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
