using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Validators.Proprietario;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Proprietario
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
