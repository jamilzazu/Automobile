using Automobile.Core.Messages;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class AtivarProprietarioCommand : Command
    {
        public Guid Id { get; private set; }
        public bool Status { get; private set; }


        public AtivarProprietarioCommand(Guid id, bool status)
        {
            AggregateId = id;
            Id = id;
            Status = status;
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
            //RuleFor(c => c.Status)
            //    .Equals(true)
            //    .WithMessage("Id do proprietário inválido");
        }
    }
}
