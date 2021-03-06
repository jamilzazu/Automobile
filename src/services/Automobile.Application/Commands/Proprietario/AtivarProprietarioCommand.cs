using Automobile.Application.Validators.Proprietario;
using Automobile.Core.Messages;
using System;

namespace Automobile.Domain.Commands.Proprietario
{
    public class AtivarProprietarioCommand : Command
    {
        public Guid Id { get; set; }

        public AtivarProprietarioCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtivarProprietarioCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
