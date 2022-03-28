using Automobile.Core.Messages;
using Automobile.Application.Validators.Marca;
using System;

namespace Automobile.Domain.Commands.Marca
{
    public class CancelarMarcaCommand : Command
    {
        public Guid Id { get; set; }

        public CancelarMarcaCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new CancelarMarcaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
