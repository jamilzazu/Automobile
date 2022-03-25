using Automobile.Core.Messages;
using FluentValidation;
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
            ValidationResult = new CancelarProprietarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CancelarProprietarioValidation : AbstractValidator<CancelarProprietarioCommand>
    {
        public CancelarProprietarioValidation()
        {
            RuleFor(c => c.Id)
                 .NotEqual(Guid.Empty)
                 .WithMessage("Id do proprietário inválido");
        }
    }
}
