using Automobile.Core.Messages;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Proprietario
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
            ValidationResult = new AtivarProprietarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtivarProprietarioValidation : AbstractValidator<AtivarProprietarioCommand>
    {
        public AtivarProprietarioValidation()
        {
             RuleFor(c => c.Id)
                 .NotEqual(Guid.Empty)
                 .WithMessage("Id do proprietário inválido");
        }
    }
}
