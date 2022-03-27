using Automobile.Core.Messages;
using Automobile.Application.Validators.Proprietario;
using System;

namespace Automobile.Domain.Commands.Proprietario
{
    public class CancelarProprietarioCommand : Command
    {
        public Guid Id { get; set; }

        public CancelarProprietarioCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new CancelarProprietarioCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
